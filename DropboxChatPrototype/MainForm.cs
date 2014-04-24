using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace DropboxChatPrototype
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string chatpath;
		string pathsep;
		
		public MainForm()
		{
			InitializeComponent();
			pathsep = System.IO.Path.DirectorySeparatorChar.ToString();
			chatpath = Application.StartupPath+pathsep+"dropchat";	
			try
			{
				Directory.CreateDirectory(chatpath);
			} catch {}
			updatechat();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (sendbutton.Text=="Login")
			{
				if(nickname.Text.Trim() == "" || nickname.Text.Trim() == "Nickname") 
				{
					MessageBox.Show("You have to enter a nickname to login!");
				}
				else
				{
					nickname.Enabled = false;
					nickname.Text = nickname.Text.Trim().Replace(":","").Replace("#","");
					input.Enabled = true;
					sendbutton.Text = "Send";
					input.Text = "";
					input.Focus();
				}
			}
			/*else if (nickname.Text=="SECUREFILE" && File.Exists(input.Text))
			{
				MessageBox.Show(WriteSecureFile(Path.GetDirectoryName(input.Text),Path.GetFileName(input.Text),File.ReadAllText(input.Text,Encoding.UTF8)),"OUTPUT:");
				input.Focus();
			}*/
			else
			{
				input.Text = input.Text.TrimEnd();
				if (input.Text.TrimStart().StartsWith("#")) input.Text = input.Text.Replace("#","");
				if(input.Text.Trim() == "") return;
				WriteSecureFile(chatpath,DateTime.Now.ToString("yyyyMMddHHmmssfff")+".chat",nickname.Text+": "+input.Text);
				input.Text = "";
				input.Focus();
				updatechat();
			}
		}
		
		string WriteSecureFile(string path, string filename, string content)
		{
			try {
				filename = filename.ToUpper();
	            using (MD5 md5Hash = MD5.Create())
	            {
	                string hash = GetMd5Hash(md5Hash, "dropchat"+filename+content);
	                string target = path+pathsep+filename+"."+hash.Substring(14,7).ToUpper();
	                File.WriteAllBytes(target,Encoding.UTF8.GetBytes(content));
	                return target;
	            }
			} catch  { MessageBox.Show("ERROR: Message file could not be written."); }
			return "";
		}

		bool IsValidFile(MD5 md5Hash, string fullpath, string content)
		{
			string hash = GetMd5Hash(md5Hash, "dropchat"+Path.GetFileNameWithoutExtension(fullpath)+content);
			if (hash.ToUpper().Substring(14,7)==Path.GetExtension(fullpath).ToUpper().Replace(".",""))
			{
				return true;
			}
			else
			{
				return false;	
			}
		}

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

		
		void TextBox3KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.WindowState = FormWindowState.Minimized;
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
		
		void updatechat()
		{
			string[] chat;
			try
			{
				chat = Directory.GetFiles(chatpath);
				Array.Sort(chat);
			} catch { return; }
			
			prechatview.Clear();
			prechatview.Font = new Font("Arial", 8f, FontStyle.Italic);
			prechatview.AppendText("DropChat - proof-of-concept of a simple chat using textfiles and Dropbox as a \"network component\"");

			using (MD5 md5Hash = MD5.Create())
            {
				foreach (string datei in chat)
				{
					string nachricht;
					try
					{
						nachricht = File.ReadAllText(datei,Encoding.UTF8);
					} catch { continue; }
					if (!IsValidFile(md5Hash,datei,nachricht)) continue;
					
					prechatview.AppendText(Environment.NewLine);
					int start = prechatview.Text.Length;
					
					string nurdatei = Path.GetFileName(datei);
					DateTime datum;
					if (nurdatei.Length>="yyyyMMddHHmmssfff".Length && DateTime.TryParseExact(nurdatei.Substring(0,"yyyyMMddHHmmssfff".Length),"yyyyMMddHHmmssfff",CultureInfo.InvariantCulture,DateTimeStyles.None, out datum))
					{
						prechatview.AppendText(datum.ToString("(HH:mm:ss) "));
						prechatview.SelectionStart = start;
						prechatview.SelectionLength = "(HH:mm:ss) ".Length;
						prechatview.SelectionFont = new Font("Arial", 8f, FontStyle.Regular);
						prechatview.SelectionLength = 0;
						start += "(HH:mm:ss) ".Length;
					}
	
					bool istspezial = nachricht.Trim().StartsWith("#");
					string schriftart = (istspezial?"Courier New":"Arial");
					
					FontStyle schrifttyp = (istspezial?FontStyle.Italic:FontStyle.Regular);
					prechatview.AppendText(nachricht);
	
					prechatview.SelectionStart = start;
					prechatview.SelectionLength = nachricht.Length;
					prechatview.SelectionFont = new Font(schriftart, 11f, schrifttyp);
					prechatview.SelectionLength = 0;
					
					if (nachricht.IndexOf(':')>=0 && !istspezial)
					{
						prechatview.SelectionStart = start;
						prechatview.SelectionLength = nachricht.IndexOf(':')+1;
						prechatview.SelectionFont = new Font(schriftart, 11f, FontStyle.Bold);
						prechatview.SelectionLength = 0;
					}
				}
			}
			if (chatview.Rtf != prechatview.Rtf)
			{
				chatview.Rtf = prechatview.Rtf;
				chatview.SelectionStart = chatview.Text.Length;
				chatview.ScrollToCaret();
			}

		}
		void Timer1Tick(object sender, EventArgs e)
		{
			updatechat();
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			nickname.SelectionStart = 0;
			nickname.SelectionLength = nickname.Text.Length;
			nickname.Focus();
		}
		
		void TextBox2KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) sendbutton.PerformClick();
		}
		
		void ChatviewLinkClicked(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}
		
		void NicknameTextChanged(object sender, EventArgs e)
		{
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
		}
		
		void ChatviewResize(object sender, EventArgs e)
		{
			chatview.Refresh();
			chatview.SelectionStart = chatview.Text.Length;
			chatview.ScrollToCaret();
		}
		
		void InputTextChanged(object sender, EventArgs e)
		{
		}
	}
}
