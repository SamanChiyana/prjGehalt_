﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace prjGehalt
{
    public partial class frmMain : Form
    {
        private ArrayList listeEingabe;
        public frmMain()
        {
            InitializeComponent();
            this.listeEingabe = new ArrayList();

        }

        private void btnHinzufügen_Click(object sender, EventArgs e)
        {
            Person person = new Person(this.txtName.Text, Convert.ToInt32(this.txtAlter.Text),
                Convert.ToInt32(this.txtGehalt.Text));

            this.listeEingabe.Add(person);
            AnzeigeListe(this.listeEingabe);

            this.txtName.Clear();
            this.txtAlter.Clear();
            this.txtGehalt.Clear();
        }

        private void rbtEinRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            AnzeigeListe(this.listeEingabe);
        }

        private void AnzeigeListe(ArrayList liste)
        {
            //Sortieren Liste
            IComparer vergleich = new Sortiereid();

            if (this.rbtName.Checked)
            {
                vergleich = new SortiereName();
            }

            if (this.rbtAlter.Checked)
            {
                vergleich = new SortiereAlter();
            }

            if (this.rbtGehalt.Checked)
            {
                vergleich = new SortiereGehalt();
            }

            liste.Sort(vergleich);

            //Löschen den alten Listenelemente
            while (this.livPersonen.Items.Count > 0)
            {
                this.livPersonen.Items.RemoveAt(0);
            }

            //Aufbau der neuen Listenelemente und Sammlung unsere Statiktikwerte
            double alterDurchschnitt = 0.0;
            double gehaltDurchschnitt = 0.0;

            foreach (Person person in liste)
            {
                ListViewItem item = new ListViewItem();
                item.Text = person.id.ToString();
                item.SubItems.Add(person.name);
                item.SubItems.Add(person.alter.ToString());
                item.SubItems.Add(person.gehalt.ToString());
                this.livPersonen.Items.Add(item);
                alterDurchschnitt += (double)person.alter;
                gehaltDurchschnitt += (double)person.gehalt;
            }

            //Anzeige der Statikwert
            alterDurchschnitt /= (double)liste.Count;
            gehaltDurchschnitt /= (double)liste.Count;

            this.txtAlterDurchschnitt.Text = alterDurchschnitt.ToString();
            this.txtGehaltDurchschnitt.Text = gehaltDurchschnitt.ToString();
            this.txtAnzahl.Text = liste.Count.ToString();

        }

    }

    //Schlisch zwecks der Übersicht = kommen hier die Klassen für den Icomparer
    public class SortiereName : IComparer
    {
        int IComparer.Compare(object links, object rechts)
        {
            return (String.Compare(((Person)links).name, ((Person)rechts).name));
        }
    }

    public class SortiereAlter : IComparer
    {
        int IComparer.Compare(object links, object rechts)
        {
            return (((Person)links).alter - ((Person)rechts).alter);
        }
    }

    public class SortiereGehalt : IComparer
    {
        int IComparer.Compare(object links, object rechts)
        {
            return (((Person)links).gehalt - ((Person)rechts).gehalt);
        }

    }

    public class Sortiereid : IComparer
    {
        int IComparer.Compare(object links, object rechts)
        {
            return (((Person)links).id - ((Person)rechts).id);
        }
    }
}
