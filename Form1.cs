using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Media;
using System.Globalization;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices.WindowsRuntime;

// Tre Howard - 10/9/22 - CSC202 - Final Project

namespace CSC202___DnD_Character_Sheet
{
    public partial class Form1 : Form
    {        
        int sneakDieTotal;

        // below is saving stats publically
        string SaveStrength, SaveDexterity, SaveConstitution, SaveIntelligence, SaveWisdom, SaveCharisma, SaveCharacterName;
        // below is saving class profile publically
        string SaveClass, SaveClassColor;
        // below is saving secondary stats publically
        string SaveProficiency, SaveInitiative, SaveMovement, SaveArmorClass;
        // below is saving weaponstats publically
        int SaveWeaponDiceAmount, SaveWeaponDiceMinimal, SaveWeaponDiceMaximum, SaveWeaponStatModifier;
        

        class ClassName // class for player class
        {
            private string className;
            public ClassName(string str)
            {
                className = str;
            }
            public string get_class()
            {
                return className;
            }          
        }

        class Rogue : ClassName // rogue class
        {
            private string RogueChangeColor;

            public Rogue(string str1, string str2) : base(str1)
            {
                RogueChangeColor = str2;
            }
            public string get_RogueChangeColor()
            {
                return RogueChangeColor;
            }
        }
        class Barbarian : ClassName // barbarian class
        {
            private string BarbarianChangeColor;

            public Barbarian(string str1, string str2) : base(str1)
            {
                BarbarianChangeColor = str2;
            }
            public string get_BarbarianChangeColor()
            {
                return BarbarianChangeColor;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void changeStatsB_Click(object sender, EventArgs e) // manually change one main stat
        {
            int maxStat = 31;

            {
                switch (changeStatCB.SelectedIndex)
                {

                    case 0:

                        if (int.TryParse(changeStatB.Text, out int statStrength))
                        {
                            if (statStrength <= maxStat)
                            {
                                strengthDisplay.Text = Convert.ToString(statStrength);
                                SaveStrength = Convert.ToString(statStrength);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Failed Strength - Catch Error");
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed Strength - Must be a number");
                            break;
                        }

                    case 1:

                        if (int.TryParse(changeStatB.Text, out int statDexterity))
                        {
                            if (statDexterity <= maxStat)
                            {
                                dexterityDisplay.Text = Convert.ToString(statDexterity);
                                SaveDexterity = Convert.ToString(statDexterity);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Failed Dexterity - Catch Error");
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed Dexterity - Must be a number");
                            break;
                        }


                    case 2:

                        if (int.TryParse(changeStatB.Text, out int statConstitution))
                        {
                            if (statConstitution <= maxStat)
                            {
                                constitutionDisplay.Text = Convert.ToString(statConstitution);
                                SaveConstitution = Convert.ToString(statConstitution);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Failed Constitution - Catch Error");
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed Constitution - Must be a number");
                            break;
                        }

                    case 3:

                        if (int.TryParse(changeStatB.Text, out int statIntelligence))
                        {
                            if (statIntelligence <= maxStat)
                            {
                                intelligenceDisplay.Text = Convert.ToString(statIntelligence);
                                SaveIntelligence = Convert.ToString(statIntelligence);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Failed Intelligence - Catch Error");
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed Intelligence - Must be a number");
                            break;
                        }

                    case 4:

                        if (int.TryParse(changeStatB.Text, out int statWisdom))
                        {
                            if (statWisdom <= maxStat)
                            {
                                wisdomDisplay.Text = Convert.ToString(statWisdom);
                                SaveWisdom = Convert.ToString(statWisdom);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Failed Wisdom - Catch Error");
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed Wisdom - Must be a number");
                            break;
                        }

                    case 5:

                        if (int.TryParse(changeStatB.Text, out int statCharisma))
                        {
                            if (statCharisma <= maxStat)
                            {
                                charismaDisplay.Text = Convert.ToString(statCharisma);
                                SaveCharisma = Convert.ToString(statCharisma);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Failed Charisma - Catch Error");
                                break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed Charisma - Must be a number");
                            break;
                        }

                    default:
                        MessageBox.Show("Failed");
                        break;
                }
            }
        }

        private void quickSetupB_Click(object sender, EventArgs e) // quick setup button for all main stats and secondary stats, using multiple methods as well as saving publically
        {
            try
            {
                string returnValue;
                

                string strength = Interaction.InputBox("Enter a number for Strength: ", "Quick Setup Guide");
                intChecker(strength);                
                strengthDisplay.Text = Convert.ToString(strength);    
                returnValue = statModifierChecker(strength);                
                strengthModifierLabel.Text = Convert.ToString(returnValue);
                returnValue = returnValue.Substring(1);
                SaveStrength = returnValue;               


                string dexterity = Interaction.InputBox("Enter a number for Dexterity: ", "Quick Setup Guide");
                intChecker(dexterity);
                dexterityDisplay.Text = Convert.ToString(dexterity);
                returnValue = statModifierChecker(dexterity);
                dexterityModifierLabel.Text = Convert.ToString(returnValue);
                returnValue = returnValue.Substring(1);
                SaveDexterity = returnValue;

                string constitution = Interaction.InputBox("Enter a number for Constitution: ", "Quick Setup Guide");
                intChecker(constitution);
                constitutionDisplay.Text = Convert.ToString(constitution);    
                returnValue = statModifierChecker(constitution);
                constitutionModifierLabel.Text = Convert.ToString(returnValue);
                returnValue = returnValue.Substring(1);
                SaveConstitution = returnValue;

                string intelligence = Interaction.InputBox("Enter a number for Intelligence: ", "Quick Setup Guide");
                intChecker(intelligence);
                intelligenceDisplay.Text = Convert.ToString(intelligence);    
                returnValue = statModifierChecker(intelligence);
                intelligenceModifierLabel.Text = Convert.ToString(returnValue);
                returnValue = returnValue.Substring(1);
                SaveIntelligence = returnValue;

                string wisdom = Interaction.InputBox("Enter a number for Wisdom: ", "Quick Setup Guide");
                intChecker(wisdom);
                wisdomDisplay.Text = Convert.ToString(wisdom);    
                returnValue = statModifierChecker(wisdom);
                wisdomModifierLabel.Text = Convert.ToString(returnValue);
                returnValue = returnValue.Substring(1);
                SaveWisdom = returnValue;

                string charisma = Interaction.InputBox("Enter a number for Charisma: ", "Quick Setup Guide");
                intChecker(charisma);
                charismaDisplay.Text = Convert.ToString(charisma);
                returnValue = statModifierChecker(charisma);
                charismaModifierLabel.Text = Convert.ToString(returnValue);
                returnValue = returnValue.Substring(1);
                SaveCharisma = returnValue;

                string initiative = Interaction.InputBox("Enter a number for Initiative: ", "Quick Setup Guide");
                intChecker(initiative);
                initiativeDisplay.Text = Convert.ToString("+" + initiative);
                SaveInitiative = initiative;

                string movement = Interaction.InputBox("Enter a number for Movement Speed: ", "Quick Setup Guide");
                intChecker(movement);
                movementSpeedDisplay.Text = Convert.ToString(movement + "ft");
                SaveMovement = movement;

                string proficiency = Interaction.InputBox("Enter a number for Proficiency Bonus: ", "Quick Setup Guide");
                intChecker(proficiency);
                proficiencyDisplay.Text = Convert.ToString("+" + proficiency);  
                SaveProficiency = proficiency;

                string armorclass = Interaction.InputBox("Enter a number for Armor Class (AC): ", "Quick Setup Guide");
                intChecker(armorclass);
                armorClassDisplay.Text = Convert.ToString(armorclass);
                SaveArmorClass = armorclass;

                string characterName = Interaction.InputBox("Enter your characters name: ", "Quick Setup Guide");
                characterNameLabel.Text = characterName;
                SaveCharacterName= characterName;
            }

            catch
            {
                MessageBox.Show("Failed To Update Stat - Not a number");
                this.Close();
            }
        }

        private string statModifierChecker(string stat) // grabs a stats number, -10 from that stat, and if it is negative number round up, if it is a positive number round down
        {            
            try
            {
                if (int.TryParse(stat, out int intStat))
                {
                    double abilityModifier;
                    double totalStat;

                    totalStat = intStat - 10;
                    abilityModifier = totalStat / 2;
                    
                    if (abilityModifier < 0)
                    {
                        double result = Math.Floor(abilityModifier);
                        return result.ToString();
                    }
                    else
                    {
                        double result = Math.Floor(abilityModifier);
                        return "+" + result.ToString();
                    }
                                   
                }
                else
                {                    
                    throw new ArgumentOutOfRangeException("Error: Modifier Checker");
                }                
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void intChecker(string stat) //converts string to int and sends back, comparing it to below 30
        {
            int maxStat = 31;


            if (int.TryParse(stat, out int outStat))
            {
                if (outStat <= maxStat)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Failed Stat - Catch Error");                    
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();

            }
        }

        public void classChangeB_Click(object sender, EventArgs e) // button to change profile for player class
        {
            string str1, str2;

            switch (classCB.SelectedIndex) // first variable is title of class, second variable is color change for title
            {
                 case 0:
                     Rogue R1 = new Rogue("Rogue", "Yellow"); 
                     try
                     {
                         str1 = R1.get_class();
                         SaveClass = str1;
                         classLabelDisplay.Text = str1;
                         str2 = R1.get_RogueChangeColor();
                         SaveClassColor = str2;
                         ClassUpdateLabels(str2);
                         characterPicture.Image = Properties.Resources.DnD_Rogue;
                         this.BackgroundImage = Properties.Resources.DnD_Rogue_Background_1;
                        break;
                     }
                     catch
                     {
                         MessageBox.Show("Change Class: Rogue Error");
                         break;
                     }

                 case 1:
                     Barbarian B1 = new Barbarian("Barbarian", "Brown"); 
                    try
                     {
                         str1 = B1.get_class();
                         SaveClass = str1;
                         classLabelDisplay.Text = str1;
                         str2 = B1.get_BarbarianChangeColor();
                         SaveClassColor = str2;
                         ClassUpdateLabels(str2);
                         characterPicture.Image = Properties.Resources.DnD_Barbarian_Project;
                         this.BackgroundImage = Properties.Resources.Dnd_Barbarian_Background_1;
                         break;
                     }
                     catch
                     {
                         MessageBox.Show("Change Class: Barbarian Error");
                         break;
                     }
            }
        }

        private void ClassUpdateLabels(string color) // updates color of title for class
        {

            switch (color)
            {
                case "Yellow":
                    classLabelDisplay.ForeColor = Color.Yellow;

                    break;

                case "Brown":
                    classLabelDisplay.ForeColor = Color.Brown;
                    break;
            }
        }

        // select a weapon and update public stats to hold this new information, updates labels and the attack button with correct stats
        private void changeWeaponB_Click(object sender, EventArgs e) 
        {            
            try
            {
                switch (weaponCB.SelectedIndex) //weaponstats = dice amount, dice minimal damage, dice maximum damage +1, string name for which stat to add to roll
                {
                    case 0:
                        //dagger
                        weaponNameLabel1.Text = "Dagger";
                        attackDiceDisplay1.Text = "1d6";
                        weaponStats(1, 1, 7, "Dexterity");
                        
                        break;

                    case 1:
                        //greataxe
                        weaponNameLabel1.Text = "Greataxe";
                        attackDiceDisplay1.Text = "3d12";
                        weaponStats(3, 1, 13, "Strength");

                        break;
                }
            }
            catch
            {
                MessageBox.Show("Failure - Change Weapon Button");
            }
        }

        // updates weapon1 with public stats from the weapon CB list (changeWeaponB_Click), also updates strength or dexterity as the modifier
        public void weaponStats (int amount, int minimal, int maximum, string str4) 
        {
            int diceAmount = amount;
            SaveWeaponDiceAmount = diceAmount;

            int diceMinimal = minimal;
            SaveWeaponDiceMinimal = minimal;

            int diceMaximum = maximum;
            SaveWeaponDiceMaximum = maximum;
                     
            switch (str4)
            {
                case "Strength":
                    SaveWeaponStatModifier = int.Parse(strengthModifierLabel.Text);

                    return;

                case "Dexterity":
                    SaveWeaponStatModifier = int.Parse(dexterityModifierLabel.Text);

                    return;
            }
            int statModifier = int.Parse(str4);           
        }

        // takes the information from weaponStats and the characters prof/stat modifier and attack rolls with them
        public void attackDaggerB_Click(object sender, EventArgs e) // now attackWeapon1B 
        {
            int statModifier;
            int proficiencyModifier;

            statModifier = SaveWeaponStatModifier;
            proficiencyModifier = int.Parse(SaveProficiency);

            attackDiceRoller(statModifier, proficiencyModifier);
        }

        // modular coding to roll attack dice with: 1d20 roll, play 20/1 sound, add prof and statModifier and display it, no reason for a return
        public int attackDiceRoller(int statModifier, int proficiencyModifier) 
        {

            int attackDie;

            Random randomAttack = new Random();
            attackDie = randomAttack.Next(1, 21);

            if (attackDie == 20)
            {
                attackDie += statModifier;
                attackDie += proficiencyModifier;
                attackDisplay1.Text = attackDie.ToString();
                SoundPlayer critSound = new SoundPlayer(@"C:\DnD Sounds\failure1hit.wav");
                critSound.Play();
                return attackDie;
                //MessageBox.Show("Critical Hit!");
            }
            else
            {
                if (attackDie == 1)
                {
                    attackDisplay1.Text = attackDie.ToString();
                    SoundPlayer failureSound = new SoundPlayer(@"C:\DnD Sounds\failure1hit.wav");
                    failureSound.Play();
                    //MessageBox.Show("Critical Failure!");
                }
                else
                {
                    if ((attackDie >= 2) && (attackDie <= 20))
                    {
                        attackDie += statModifier;
                        attackDie += proficiencyModifier;
                        attackDisplay1.Text = attackDie.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error: Dice broke somehow?");
                    }
                }
                return 0;
            }
        }

        // damage button takes public stats and send them to the diceRoller
        private void damageDaggerB_Click(object sender, EventArgs e) // now damageWeapon1B
        {
            int damageTotal;

            damageTotal = damageDiceRoller(SaveWeaponDiceAmount, SaveWeaponDiceMinimal, SaveWeaponDiceMaximum);
            attackDisplay1.Text = Convert.ToString(damageTotal);
        }

        // takes information from the weaponStats and the publically saved stats from weaponStats and rolls it here for damage. Loop is for multiple dice (3d12 for example)
        private int damageDiceRoller(int diceAmount, int diceMinimal, int diceDamage)
        {
            int total = 0;
            int diceRoll;            

            Random randomAttack = new Random(); 

            for (int i = 0; i < diceAmount; i++)
            {        
                diceRoll = randomAttack.Next(diceMinimal, diceDamage);
                total += diceRoll;                
            }
            return total;
        }        

        private void characterNameB_Click(object sender, EventArgs e) // changes character name on button click
        {
            string charName = characterNameTextBox.Text;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string upperCase = textInfo.ToTitleCase(charName);
            characterNameLabel.Text = upperCase;
            SaveCharacterName = Convert.ToString(characterNameTextBox.Text);
        }

        // rogue sneak attack damage, rolls amount of dice depending on what you selected in the CB
        private void sneakAttackDamageB_Click(object sender, EventArgs e) // perk1Display
        {
            int sneakDie;
            int sneakRoll = sneakAttackDiceCB.SelectedIndex;

            Random rnd = new Random();

            for (int i = 0; i <= sneakRoll; i++)
            {
                sneakDie = rnd.Next(1, 7);
                sneakDieTotal += sneakDie;
                perk1Display.Text = sneakDieTotal.ToString();
            }
                sneakDieTotal = 0;
        }

        // save (NOT FULLY DONE, only main stats are done)
        private void saveProfileB_Click(object sender, EventArgs e)
        {
            StreamWriter outputFile;            
            saveFileDialog.InitialDirectory = "C:/Documents";
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] characterStats = { SaveStrength, SaveDexterity, SaveConstitution, SaveIntelligence, SaveWisdom, SaveCharisma, SaveCharacterName};
                    outputFile = File.CreateText(saveFileDialog.FileName);

                    for (int index = 0; index < characterStats.Length; index++)
                    {
                        outputFile.WriteLine(characterStats[index]);
                    }
                    outputFile.Close();
                    MessageBox.Show("Save Successful!");
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Save Error: 1000");
            }
        }

        // load (NOT FULLY DONE, only main stats are done)
        private void loadProfileB_Click(object sender, EventArgs e)
        {

            int loadStrength, loadDexterity, loadConstitution, loadIntelligence, loadWisdom, loadCharisma; 
            string loadCharacterName;

            StreamReader inputFile;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFileDialog.FileName);

                    loadStrength = int.Parse(inputFile.ReadLine());
                    strengthDisplay.Text = loadStrength.ToString();

                    loadDexterity = int.Parse(inputFile.ReadLine());
                    dexterityDisplay.Text = loadDexterity.ToString();

                    loadConstitution = int.Parse(inputFile.ReadLine());
                    constitutionDisplay.Text = loadConstitution.ToString();

                    loadIntelligence = int.Parse(inputFile.ReadLine());
                    intelligenceDisplay.Text = loadIntelligence.ToString();

                    loadWisdom = int.Parse(inputFile.ReadLine());
                    wisdomDisplay.Text = loadWisdom.ToString();

                    loadCharisma = int.Parse(inputFile.ReadLine());
                    charismaDisplay.Text = loadCharisma.ToString();

                    // this loads the line in the file to loadCharacterName, then creates the textInfo for ToTitleCase and loads loadCharacterName to the string upperCase
                    // then it applies the uppercase ruling/coding and then makes loadCharacterName be the same information as upperCase, and finally applying it to the label
                    // the reason I had to do this was because if you put ur name in as "tre h" and it applies as "Tre H" on the name change button, it still saves to the file as
                    // "tre h" and not "Tre H" so I have to run this code during load as well
                    loadCharacterName = inputFile.ReadLine();
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    string upperCase = textInfo.ToTitleCase(loadCharacterName);
                    loadCharacterName = upperCase;
                    characterNameLabel.Text = loadCharacterName.ToString();

                    inputFile.Close();
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Not valid data");
            }            
        }    

        // add inventory item to list
        private void inventoryAddB_Click(object sender, EventArgs e)
        {
            inventoryListAdd(inventoryTB.Text);
        }

        // remove inventory item from list
        private void inventoryRemoveB_Click(object sender, EventArgs e)
        {
            inventoryListRemove(inventoryLB.SelectedIndex);
        }

        // process to add inventory item to inventory list
        public void inventoryListAdd(string inventoryIndex)
        {
            inventoryLB.Items.Add(inventoryIndex);
        }

        // process to remove item from inventory list
        public void inventoryListRemove(int inventoryIndex)
        {
            inventoryLB.Items.Remove(inventoryLB.SelectedItem);
        }

        // exit application
        private void exitB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



