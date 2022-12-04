using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KrediFaizHesaplamaa
{
    public partial class KrediFaizHesaplama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime tarih;
            tarih = DateTime.Now;

            double f, oran, vadedeger, carpan, ayliktaksit, gm;
            f = 0;
            if (DropDownList1.SelectedValue == "1")
            {
                f = 0.69;
                TextBox4.Text = f.ToString();
            }
            if (DropDownList1.SelectedValue == "2")
            {
                f = 0.55;
                TextBox4.Text = f.ToString();
            }
            if (DropDownList1.SelectedValue == "3")
            {
                f = 0.50;
                TextBox4.Text = f.ToString();
            }
            vadedeger = Convert.ToDouble(DropDownList2.SelectedItem.Text);
            oran = ((vadedeger + 1) / 2) * f;
            carpan = oran / 100 + 1;
            ayliktaksit = (Convert.ToDouble(TextBox1.Text) * carpan) / vadedeger;
            TextBox2.Text = ayliktaksit.ToString("0.##");
            gm = (ayliktaksit * Convert.ToDouble(DropDownList2.SelectedItem.Text));
            TextBox3.Text = gm.ToString();

            plan.InnerHtml = "<table cellspacing='15' cellpadding='15' style='border:1px; border-style:solid;text-align:center;'>";
            plan.InnerHtml += "<tr> <th>Sıra No</th><th>Tarih</th><th>Ödeme Miktarı</th><th>Geriye kalan Miktar </th> </tr>";
            for (int i = 1; i <= vadedeger; i++)
            {
                if (gm <= 0)
                {
                    gm = 0;
                }
                plan.InnerHtml += "<tr><td>" + i + "</td><td>" + tarih.AddMonths(i).ToShortDateString() + "</td><td>" + ayliktaksit.ToString("0.##") + "</td><td>" + (gm - (ayliktaksit * i)).ToString("0.##") + "</td></tr>";
            }
            plan.InnerHtml += "</table>";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedValue == "1")
            {
                for (int i = 1; i < 37; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                for (int i = 1; i < 61; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                for (int i = 1; i < 121; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }
            }
        }
    }
}