using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebAutoClick
{
  public partial class Form1 : Form
  {
    private Boolean loadingFinished = false;

    public Form1()
    {
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button1.Enabled = false;
      this.webBrowser1.Navigate("http://www.facebook.com");
      load();
    }

    private void load()
    {
      while (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete)
      {
        Application.DoEvents();
      }
      loadingFinished = true;
      this.button1.Enabled = true;
    }

    private void login()
    {
      while (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete)
      {
        Application.DoEvents();
      }
      HtmlDocument doc = this.webBrowser1.Document;
      for (int i = 0; i < doc.All.Count; i++)
      {
        if (doc.All[i].Id == "email")
        {
          //doc.All[i].SetAttribute("value", account);
        }
        if (doc.All[i].Id == "pass")
        {
          //doc.All[i].SetAttribute("value", password);
        }
        if (doc.All[i].Id == "loginbutton")
        {
          //doc.All[i].InvokeMember("click");
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      HtmlDocument doc = this.webBrowser1.Document;
      while (doc == null)
      {
        Application.DoEvents();
      }
      for (int i = 0; i < doc.All.Count; i++)
      {
        if (doc.All[i].GetAttribute("class") == "UFIPagerLink")
        {
          doc.All[i].InvokeMember("click");
        }
      }

      for (int i = 0; i < doc.All.Count; i++)
      {
        if (doc.All[i].GetAttribute("title") == "覺得這很讚" || doc.All[i].GetAttribute("title") == "說這則留言讚" || doc.All[i].GetAttribute("title") == "Like this" || doc.All[i].GetAttribute("title") == "Like this comment")
        {
          doc.All[i].InvokeMember("click");
        }
      }
    }

  }
}
