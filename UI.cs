﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    public class TicketMachine : Form
    {
        ComboBox fromBox;
        ComboBox toBox;
        RadioButton firstClass;
        RadioButton secondClass;
        RadioButton oneWay;
        RadioButton returnWay;
        RadioButton noDiscount;
        RadioButton twentyDiscount;
        RadioButton fortyDiscount;
        ComboBox payment;
        Button pay;

        Ticket ticket;

        public TicketMachine()
        {
            initializeControls();
        }

        private void CreateTicket(UIInfo info)
        {
            ticket = new Ticket();

            ticket.trajectory.Destination = info.To;
            ticket.trajectory.Origin = info.From;

            if (info.Way == UIWay.Return)
                ticket.isReturn = true;
            else
                ticket.isReturn = false;
            // Compute the column in the table based on choices

            // First based on class

            if (info.Class == UIClass.FirstClass)
                ticket.ticketClass = TicketClass.First;
            else
                ticket.ticketClass = TicketClass.Second;
            // Then, on the discount


            switch (info.Discount)
            {
                case UIDiscount.NoDiscount:
                    ticket.discount = Discount.Zero;
                    break;
                case UIDiscount.TwentyDiscount:
                    ticket.discount = Discount.Twenty;
                    break;
                case UIDiscount.FortyDiscount:
                    ticket.discount = Discount.Forty;
                    break;
            }
        }

        private void Pay(UIInfo info)
        {
            // Get price
            float price = DBase.getPrice(ticket);
            if (ticket.isReturn)
            {
                price *= 2;
            }
            // Pay
            Payment payment;
            switch (info.Payment)
            {
                case UIPayment.CreditCard:
                    payment = new CreditCard(price);
                    break;
                case UIPayment.DebitCard:
                    payment = new DebitCard(price);
                    break;
                default: //case UIPayment.Cash
                    payment = new Cash(price);
                    break;
            }
            payment.Pay();
        }
        private void handlePayment(UIInfo info)
        {
            CreateTicket(info);
            Pay(info);
        }

        #region Set-up -- don't look at it
        private void initializeControls()
        {
            // Set label
            this.Text = "MSO Lab Exercise III";
            // this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Width = 500;
            this.Height = 210;
            // Set layout
            var grid = new TableLayoutPanel();
            grid.Dock = DockStyle.Fill;
            grid.Padding = new Padding(5);
            this.Controls.Add(grid);
            grid.RowCount = 4;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            grid.ColumnCount = 6;
            for (int i = 0; i < 6; i++)
            {
                ColumnStyle c = new ColumnStyle(SizeType.Percent, 16.66666f);
                grid.ColumnStyles.Add(c);
            }
            // Create From and To
            var fromLabel = new Label();
            fromLabel.Text = "From:";
            fromLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(fromLabel, 0, 0);
            fromLabel.Dock = DockStyle.Fill;
            fromBox = new ComboBox();
            fromBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fromBox.Items.AddRange(Tariefeenheden.getStations());
            fromBox.SelectedIndex = 0;
            grid.Controls.Add(fromBox, 1, 0);
            grid.SetColumnSpan(fromBox, 2);
            fromBox.Dock = DockStyle.Fill;
            var toLabel = new Label();
            toLabel.Text = "To:";
            toLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(toLabel, 3, 0);
            toLabel.Dock = DockStyle.Fill;
            toBox = new ComboBox();
            toBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toBox.Items.AddRange(Tariefeenheden.getStations());
            toBox.SelectedIndex = 0;
            grid.Controls.Add(toBox, 4, 0);
            grid.SetColumnSpan(toBox, 2);
            toBox.Dock = DockStyle.Fill;
            // Create groups
            GroupBox classGroup = new GroupBox();
            classGroup.Text = "Class";
            classGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(classGroup, 0, 1);
            grid.SetColumnSpan(classGroup, 2);
            var classGrid = new TableLayoutPanel();
            classGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            classGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            classGrid.Dock = DockStyle.Fill;
            classGroup.Controls.Add(classGrid);
            GroupBox wayGroup = new GroupBox();
            wayGroup.Text = "Amount";
            wayGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(wayGroup, 2, 1);
            grid.SetColumnSpan(wayGroup, 2);
            var wayGrid = new TableLayoutPanel();
            wayGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            wayGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            wayGrid.Dock = DockStyle.Fill;
            wayGroup.Controls.Add(wayGrid);
            GroupBox discountGroup = new GroupBox();
            discountGroup.Text = "Discount";
            discountGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(discountGroup, 4, 1);
            grid.SetColumnSpan(discountGroup, 2);
            var discountGrid = new TableLayoutPanel();
            discountGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            discountGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            discountGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            discountGrid.Dock = DockStyle.Fill;
            discountGroup.Controls.Add(discountGrid);
            // Create radio buttons
            firstClass = new RadioButton();
            firstClass.Text = "1st class";
            firstClass.Checked = true;
            classGrid.Controls.Add(firstClass);
            secondClass = new RadioButton();
            secondClass.Text = "2nd class";
            classGrid.Controls.Add(secondClass);
            oneWay = new RadioButton();
            oneWay.Text = "One-way";
            oneWay.Checked = true;
            wayGrid.Controls.Add(oneWay);
            returnWay = new RadioButton();
            returnWay.Text = "Return";
            wayGrid.Controls.Add(returnWay);
            noDiscount = new RadioButton();
            noDiscount.Text = "No discount";
            noDiscount.Checked = true;
            discountGrid.Controls.Add(noDiscount);
            twentyDiscount = new RadioButton();
            twentyDiscount.Text = "20% discount";
            discountGrid.Controls.Add(twentyDiscount);
            fortyDiscount = new RadioButton();
            fortyDiscount.Text = "40% discount";
            discountGrid.Controls.Add(fortyDiscount);
            // Payment option
            Label paymentLabel = new Label();
            paymentLabel.Text = "Payment by:";
            paymentLabel.Dock = DockStyle.Fill;
            paymentLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(paymentLabel, 0, 2);
            payment = new ComboBox();
            payment.DropDownStyle = ComboBoxStyle.DropDownList;
            payment.Items.AddRange(new String[] { "Credit card", "Debit card", "Cash" });
            payment.SelectedIndex = 0;
            payment.Dock = DockStyle.Fill;
            grid.Controls.Add(payment, 1, 2);
            grid.SetColumnSpan(payment, 5);
            // Pay button
            pay = new Button();
            pay.Text = "Pay";
            pay.Dock = DockStyle.Fill;
            grid.Controls.Add(pay, 0, 3);
            grid.SetColumnSpan(pay, 6);
            // Set up event
            pay.Click += (object sender, EventArgs e) => handlePayment(getUIInfo());
        }

        private UIInfo getUIInfo()
        {
            UIClass cls;
            if (firstClass.Checked)
                cls = UIClass.FirstClass;
            else
                cls = UIClass.SecondClass;

            UIWay way;
            if (oneWay.Checked)
                way = UIWay.OneWay;
            else
                way = UIWay.Return;

            UIDiscount dis;
            if (noDiscount.Checked)
                dis = UIDiscount.NoDiscount;
            else if (twentyDiscount.Checked)
                dis = UIDiscount.TwentyDiscount;
            else
                dis = UIDiscount.FortyDiscount;

            UIPayment pment;
            switch ((string)payment.SelectedItem)
            {
                case "Credit card":
                    pment = UIPayment.CreditCard;
                    break;
                case "Debit card":
                    pment = UIPayment.DebitCard;
                    break;
                default:
                    pment = UIPayment.Cash;
                    break;
            }

            return new UIInfo((string)fromBox.SelectedItem,
                (string)toBox.SelectedItem,
                cls, way, dis, pment);
        }
        #endregion
    }
}

