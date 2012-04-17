using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Octgn.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Deck_Converter
{
    public partial class Main : Form
    {
        string gameid;
        Boolean sideboard = false;
        string input = string.Empty;
        string gamepath;
        int gameindex;
        string extension;
        private Deck deck;

        public Main()
        {
            InitializeComponent();
        }

        private void ConvertOCTGN()
        {
            textBox1.Text += "// Deck file for Magic Workstation (http://www.magicworkstation.com)" + Environment.NewLine;
            textBox1.Text += Environment.NewLine;
            textBox1.Text += "// OCTGN conversion" + Environment.NewLine;

            GamesRepository mygame = new Octgn.Data.GamesRepository();

            XmlTextReader reader = new XmlTextReader(input);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.                              
                        while (reader.MoveToNextAttribute()) // Read the attributes. 
                        {
                            if (reader.Value == "Sideboard")
                                if (reader.IsEmptyElement == false)
                                {
                                    sideboard = true;
                                    textBox1.Text += Environment.NewLine;
                                    textBox1.Text += "// Sideboard" + Environment.NewLine;
                                }

                            if (reader.Name == "game")
                                gameid = reader.Value;

                            if (reader.Name == "qty")
                                if (sideboard != true)
                                    textBox1.Text += "    " + reader.Value;
                                else textBox1.Text += "SB: " + reader.Value;

                            if (reader.Name == "id")
                            {
                                Guid setid = Guid.Parse(reader.Value);
                                string temp = mygame.Games[gameindex].GetCardById(setid).Set.Name;

                                #region MWS Set Abbreviations
                                // Switch to abbriviations
                                if (temp == "Alliances")
                                    temp = "AL";
                                if (temp == "Antiquities")
                                    temp = "5e";
                                if (temp == "Apocalypse")
                                    temp = "AP";
                                if (temp == "Arabian Nights")
                                    temp = "AN";
                                if (temp == "Betrayers of Kamigawa")
                                    temp = "BOK";
                                if (temp == "Champions of Kamigawa")
                                    temp = "CHK";
                                if (temp == "Coldsnap")
                                    temp = "CS";
                                if (temp == "Dark Ascension")
                                    temp = "DKA";
                                if (temp == "Darksteel")
                                    temp = "DS";
                                if (temp == "Dissension")
                                    temp = "DIS";
                                if (temp == "Duel Decks: Divine vs. Demonic")
                                    temp = "DDC";
                                if (temp == "Duel Decks: Elves vs. Goblins")
                                    temp = "EVG";
                                if (temp == "Duel Decks: Garruk vs. Liliana")
                                    temp = "DDD";
                                if (temp == "Duel Decks: Jace vs. Chandra")
                                    temp = "DD2";
                                if (temp == "Duel Decks: Phyrexia vs. The Coalition")
                                    temp = "DDE";
                                if (temp == "Eighth Edition")
                                    temp = "8E";
                                if (temp == "Exodus")
                                    temp = "EX";
                                if (temp == "Fallen Empires")
                                    temp = "FE";
                                if (temp == "Fifth Dawn")
                                    temp = "FD";
                                if (temp == "Fifth Edition")
                                    temp = "5E";
                                if (temp == "Fourth Edition")
                                    temp = "4E";
                                if (temp == "From the Vault: Dragons")
                                    temp = "DRB";
                                if (temp == "From the Vault: Exiled")
                                    temp = "V09";
                                if (temp == "From the Vault: Relics")
                                    temp = "V10";
                                if (temp == "Future Sight")
                                    temp = "FUT";
                                if (temp == "Guildpact")
                                    temp = "GP";
                                if (temp == "Homelands")
                                    temp = "HL";
                                if (temp == "Ice Age")
                                    temp = "IA";
                                if (temp == "Innistrad")
                                    temp = "INN";
                                if (temp == "Invasion")
                                    temp = "IN";
                                if (temp == "Judgment")
                                    temp = "JU";
                                if (temp == "Legends")
                                    temp = "LG";
                                if (temp == "Legions")
                                    temp = "LE";
                                if (temp == "Limited Edition Alpha")
                                    temp = "A";
                                if (temp == "Limited Edition Beta")
                                    temp = "B";
                                if (temp == "Mercadian Masques")
                                    temp = "MM";
                                if (temp == "Mirage")
                                    temp = "MI";
                                if (temp == "Mirrodin")
                                    temp = "MR";
                                if (temp == "Nemesis")
                                    temp = "NE";
                                if (temp == "New Phyrexia")
                                    temp = "NPH";
                                if (temp == "Ninth Edition")
                                    temp = "9E";
                                if (temp == "Odyssey")
                                    temp = "OD";
                                if (temp == "Onslaught")
                                    temp = "ON";
                                if (temp == "Planar Chaos")
                                    temp = "PLC";
                                if (temp == "Planeshift")
                                    temp = "PS";
                                if (temp == "Prophecy")
                                    temp = "PY";
                                if (temp == "Ravnica: City of Guilds")
                                    temp = "RAV";
                                if (temp == "Revised Edition")
                                    temp = "R";
                                if (temp == "Saviors of Kamigawa")
                                    temp = "SOK";
                                if (temp == "Scourge")
                                    temp = "SC";
                                if (temp == "Seventh Edition")
                                    temp = "7E";
                                if (temp == "Classic Sixth Edition")
                                    temp = "6E";
                                if (temp == "Stronghold")
                                    temp = "SH";
                                if (temp == "Tempest")
                                    temp = "TE";
                                if (temp == "Tenth Edition")
                                    temp = "10E";
                                if (temp == "The Dark")
                                    temp = "DK";
                                if (temp == "Time Spiral")
                                    temp = "TSP";
                                if (temp == "Torment")
                                    temp = "TO";
                                if (temp == "Unglued")
                                    temp = "UG";
                                if (temp == "Unhinged")
                                    temp = "UNH";
                                if (temp == "Unlimited Edition")
                                    temp = "U";
                                if (temp == "Urza's Destiny")
                                    temp = "UD";
                                if (temp == "Urza's Legacy")
                                    temp = "UL";
                                if (temp == "Urza's Saga")
                                    temp = "US";
                                if (temp == "Visions")
                                    temp = "VI";
                                if (temp == "Weatherlight")
                                    temp = "WL";
                                if (temp == "Alara Reborn")
                                    temp = "ARB";
                                if (temp == "Conflux")
                                    temp = "CFX";
                                if (temp == "Eventide")
                                    temp = "EVE";
                                if (temp == "Lorwyn")
                                    temp = "LRW";
                                if (temp == "Magic 2010")
                                    temp = "M10";
                                if (temp == "Magic 2011")
                                    temp = "M11";
                                if (temp == "Magic 2012")
                                    temp = "M12";
                                if (temp == "Morningtide")
                                    temp = "MOR";
                                if (temp == "Rise of the Eldrazi")
                                    temp = "ROE";
                                if (temp == "Scars of Mirrodin")
                                    temp = "SOM";
                                if (temp == "Shadowmoor")
                                    temp = "SHM";
                                if (temp == "Shards of Alara")
                                    temp = "ALA";
                                if (temp == "Worldwake")
                                    temp = "WWK";
                                if (temp == "Zendikar")
                                    temp = "ZEN";
                                if (temp == "Mirrodin Besieged")
                                    temp = "MBS";
                                #endregion

                                textBox1.Text += " " + "[" + temp + "]" + " " + mygame.Games[gameindex].GetCardById(setid).Name;
                            }
                        }

                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.                        
                        textBox1.Text += Environment.NewLine;
                        break;
                }
            }
        }

        private void ConvertMWS()
        {
            GamesRepository mygame = new Octgn.Data.GamesRepository();
            Game game = mygame.Games[gameindex];
            Deck newDeck = new Deck(mygame.Games[gameindex]);
            int i = 0; // Decks have 4 sections. Main = 0, Sideboard = 1, Command Zone = 2, and Plains/Schemes = 3 

            TextReader reader = new StreamReader(textBox2.Text);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                i = 0;
                if (line != "")
                {
                    if (!line.Contains("//"))
                    {
                        if (line.Remove(3) == "SB:")
                        {
                            i = 1;
                            line = line.Remove(0, 3);
                        }

                        if ((line.Contains('[')) && (line.Contains(']')))
                        {
                            int count = line.IndexOf('[');
                            line = line.Remove(count, line.IndexOf(']') - count + 1);
                        }

                        line = line.Trim();
                        var quantity = line.Remove(line.IndexOf(' ')).Trim();                                                
                        var name = line.Remove(0, line.IndexOf(' ') + 1).Trim();
                        newDeck.Sections[i].Cards.Add(new Deck.Element { Card = game.GetCardByName(name), Quantity = Convert.ToByte(quantity) });
                    }
                }
            }
            deck = newDeck;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            string ext = Path.GetExtension(textBox2.Text.ToLower());
            if (ext == ".o8d".ToLower())
                ConvertOCTGN();

            if (ext == ".mwDeck".ToLower())
                ConvertMWS();

            if (ext == ".dec".ToLower())
                ConvertMWS();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {            
            GamesRepository mygame = new Octgn.Data.GamesRepository();            
            OpenFileDialog dialogue = new OpenFileDialog();
            dialogue.Filter = "OCTGN deck files (*.o8d) | *.o8d";
            dialogue.Filter += "| Magic Workstation files (*.mwDeck) | *.mwDeck";
            dialogue.Filter += "| MTGO/Apprentice files (*.dec) | *.dec";
            dialogue.InitialDirectory = mygame.Games[gameindex].DefaultDecksPath;
            gamepath = mygame.Games[gameindex].DefaultDecksPath;

            if (dialogue.ShowDialog() == DialogResult.OK)
                input = dialogue.FileName;
            if (dialogue.FileName == string.Empty)
                return;
            extension = Path.GetExtension(input);
            textBox2.Text = input;
            textBox1.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogue = new SaveFileDialog();
            dialogue.InitialDirectory = gamepath;
            if (extension.ToLower() == ".o8d".ToLower())
            {
                dialogue.Filter = "MWS deck files (*.mwDeck) | *.mwDeck";
                dialogue.FileName = Path.GetFileNameWithoutExtension(input) + ".mwDeck";
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    input = dialogue.FileName;
                    File.WriteAllText(input, textBox1.Text);
                }
            }
            if (extension.ToLower() == ".mwDeck".ToLower())
            {
                dialogue.Filter = "OCTGN deck files (*.o8d) | *.o8d";
                dialogue.FileName = Path.GetFileNameWithoutExtension(input) + ".o8d";
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    input = dialogue.FileName;
                    deck.Save(input);                    
                }
            }
            if (extension.ToLower() == ".dec".ToLower())
            {
                dialogue.Filter = "OCTGN deck files (*.o8d) | *.o8d";
                dialogue.FileName = Path.GetFileNameWithoutExtension(input) + ".o8d";
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    input = dialogue.FileName;
                    deck.Save(input);
                }
            }                                        
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.Height == 104)
            {
                this.Height = 535;
                Assembly rImage = Assembly.GetExecutingAssembly();
                Stream myimage = rImage.GetManifestResourceStream("Deck_Converter.Resources.arrow-up_16.png");
                Bitmap bimage = new Bitmap(myimage);
                btnDetails.Image = bimage;
            }
            else
                if (this.Height == 535)
                {
                    this.Height = 104;
                    Assembly rImage = Assembly.GetExecutingAssembly();
                    Stream myimage = rImage.GetManifestResourceStream("Deck_Converter.Resources.arrow-down_16.png");
                    Bitmap bimage = new Bitmap(myimage);
                    btnDetails.Image = bimage;
                }
        }        

        private void Main_Load(object sender, EventArgs e)
        {
            GamesRepository mygame = new Octgn.Data.GamesRepository();
            int gamecount = mygame.Games.Count;
            string mtg = "Magic The Gathering";
            int loop = 0;
            try
            {
                while (loop <= gamecount - 1)
                {
                    if (mtg == mygame.Games[gamecount].Name)
                    {
                        gameindex = gamecount;
                        break;
                    }
                    else
                        MessageBox.Show("Magic The Gathering not found");
                    loop++;
                }
            }
            catch
            {
            }
        }          

    }
}
