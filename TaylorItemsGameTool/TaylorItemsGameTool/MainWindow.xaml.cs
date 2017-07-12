using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TaylorItemsGameTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int checkIfInt;
        private string itemName;
        private string itemType;
        private string damageType;
        private int armorBonus;
        private int damageValue = 1;
        private int itemLevel = 1;
        private int requiredLevel = 1;
        private int saleValue = 1;
        private string wepSubType;
        private string bindingRule;

        private string[] itemTypes = { "Weapon", "Chest Armor", "Leg Armor", "Glove", "Boot", "Helm", "Shield" };
        private string[] damageTypes = { "Slashing ", "Piercing", "Crushing", "Magic" };
        private string[] weaponSubTypes = { "Sword", "Axe", "Bow", "Dagger", "Hammer", "Mace", "Wand", "Staff", "Fist" };
        private string[] bindingRules = { "None", "OnEquip", "OnPickup", "Account" };
        public MainWindow()
        {
            InitializeComponent();
            foreach(string item in itemTypes)//populate itemTypeList combobox
            {
                itemTypeList.Items.Add(item);
                itemTypeList.SelectedIndex = 0;
            }
            foreach(string item in damageTypes)//populate damageTypesList
            {
                damageTypeList.Items.Add(item);
                damageTypeList.SelectedIndex = 0;
            }
            foreach (string item in weaponSubTypes)//populate wepSubTypeList
            {
                wepSubTypeList.Items.Add(item);
                wepSubTypeList.SelectedIndex = 0;
            }
            foreach (string item in bindingRules)//populate bindRuleList
            {
                bindRuleList.Items.Add(item);
                bindRuleList.SelectedIndex = 0;
            }
        }

        private void itemNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validate item name text
            if(itemNameText.Text!="Input Name"&&int.TryParse(itemNameText.Text,out checkIfInt) == false)
            {
                itemName = itemNameText.Text;
            }
            else
            {
                itemNameText.Text = "Input Name";
            }
        }

        private void itemTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemType = itemTypeList.SelectedValue.ToString();
            if (itemType == "Weapon")
            {
                damageTypeList.IsEnabled = true;
                damageNum.IsEnabled = true;
                wepSubTypeList.IsEnabled = true;
                armorBonusNum.IsEnabled = false;
            }
            else
            {
                damageTypeList.IsEnabled = false;
                damageNum.IsEnabled = false;
                wepSubTypeList.IsEnabled = false;
                armorBonusNum.IsEnabled = true;
            }
        }

        private void itemLevelNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validate item level text
            if(int.TryParse(itemLevelNum.Text,out checkIfInt) == true && checkIfInt >= 1 && checkIfInt <= 300)
            {
                itemLevel = checkIfInt;
            }
            else
            {
                itemLevelNum.Text = "1";
            }
        }

        private void requiredLevelNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validate required level text
            if (int.TryParse(requiredLevelNum.Text, out checkIfInt) == true && checkIfInt >= 1 && checkIfInt <= 100)
            {
               requiredLevel = checkIfInt;
            }
            else
            {
                requiredLevelNum.Text = "1";
            }
        }

        private void saleValueNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validate required level text
            if (int.TryParse(saleValueNum.Text, out checkIfInt) == true && checkIfInt >= 1)
            {
                saleValue = checkIfInt;
            }
            else
            {
                saleValueNum.Text = "1";
            }
        }

        private void armorBonusNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validate required level text
            if (int.TryParse(armorBonusNum.Text, out checkIfInt) == true && checkIfInt >= 1)
            {
                armorBonus = checkIfInt;
            }
            else
            {
                armorBonusNum.Text = "1";
            }
        }

        private void rogueClass_Checked(object sender, RoutedEventArgs e)
        {
            if (anyClass.IsChecked.GetValueOrDefault() == true&&rogueClass.IsChecked.GetValueOrDefault()==true)
            {
                anyClass.IsChecked = false;
            }
            else if(rogueClass.IsChecked.GetValueOrDefault()==false&& warriorClass.IsChecked.GetValueOrDefault() == false
                && clericClass.IsChecked.GetValueOrDefault() == false && thiefClass.IsChecked.GetValueOrDefault() == false
                && wizardClass.IsChecked.GetValueOrDefault() == false)
            {
                anyClass.IsChecked = true;
            }
        }

        private void warriorClass_Checked(object sender, RoutedEventArgs e)
        {
            if (anyClass.IsChecked.GetValueOrDefault() == true && warriorClass.IsChecked.GetValueOrDefault() == true)
            {
                anyClass.IsChecked = false;
            }
            else if (rogueClass.IsChecked.GetValueOrDefault() == false && warriorClass.IsChecked.GetValueOrDefault() == false
               && clericClass.IsChecked.GetValueOrDefault() == false && thiefClass.IsChecked.GetValueOrDefault() == false
               && wizardClass.IsChecked.GetValueOrDefault() == false)
            {
                anyClass.IsChecked = true;
            }
        }

        private void damageTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            damageType = damageTypeList.SelectedValue.ToString();
        }

        private void wepSubTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wepSubType = wepSubTypeList.SelectedValue.ToString();
        }

        private void bindRuleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bindingRule = bindRuleList.SelectedValue.ToString();
        }

        private void damageNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validate damage num text
            if (int.TryParse(damageNum.Text, out checkIfInt) == true && checkIfInt >= 1&&checkIfInt <=100)
            {
                damageValue = checkIfInt;
            }
            else
            {
                damageNum.Text = "1";
            }
        }

        private void wizardClass_Checked(object sender, RoutedEventArgs e)
        {
            if (anyClass.IsChecked.GetValueOrDefault() == true && wizardClass.IsChecked.GetValueOrDefault() == true)
            {
                anyClass.IsChecked = false;
            }
            else if (rogueClass.IsChecked.GetValueOrDefault() == false && warriorClass.IsChecked.GetValueOrDefault() == false
               && clericClass.IsChecked.GetValueOrDefault() == false && thiefClass.IsChecked.GetValueOrDefault() == false
               && wizardClass.IsChecked.GetValueOrDefault() == false)
            {
                anyClass.IsChecked = true;
            }
        }

        private void clericClass_Checked(object sender, RoutedEventArgs e)
        {
            if (anyClass.IsChecked.GetValueOrDefault() == true && clericClass.IsChecked.GetValueOrDefault() == true)
            {
                anyClass.IsChecked = false;
            }
            else if (rogueClass.IsChecked.GetValueOrDefault() == false && warriorClass.IsChecked.GetValueOrDefault() == false
               && clericClass.IsChecked.GetValueOrDefault() == false && thiefClass.IsChecked.GetValueOrDefault() == false
               && wizardClass.IsChecked.GetValueOrDefault() == false)
            {
                anyClass.IsChecked = true;
            }
        }

        private void thiefClass_Checked(object sender, RoutedEventArgs e)
        {
            if (anyClass.IsChecked.GetValueOrDefault() == true && thiefClass.IsChecked.GetValueOrDefault() == true)
            {
                anyClass.IsChecked = false;
            }
            else if (rogueClass.IsChecked.GetValueOrDefault() == false && warriorClass.IsChecked.GetValueOrDefault() == false
               && clericClass.IsChecked.GetValueOrDefault() == false && thiefClass.IsChecked.GetValueOrDefault() == false
               && wizardClass.IsChecked.GetValueOrDefault() == false)
            {
                anyClass.IsChecked = true;
            }
        }

        private void anyClass_Checked(object sender, RoutedEventArgs e)
        {
            if (anyClass.IsChecked.GetValueOrDefault() == true)
            {
                rogueClass.IsChecked = false;
                warriorClass.IsChecked = false;
                clericClass.IsChecked = false;
                wizardClass.IsChecked = false;
                thiefClass.IsChecked = false;
            }
           
        }

        private void elfRace_Checked(object sender, RoutedEventArgs e)
        {
            if (anyRace.IsChecked.GetValueOrDefault() == true && elfRace.IsChecked.GetValueOrDefault() == true)
            {
                anyRace.IsChecked = false;
            }
            else if (elfRace.IsChecked.GetValueOrDefault() == false && dwarfRace.IsChecked.GetValueOrDefault() == false
               && halflingRace.IsChecked.GetValueOrDefault() == false && humanRace.IsChecked.GetValueOrDefault() == false
               && trollRace.IsChecked.GetValueOrDefault() == false)
            {
                anyRace.IsChecked = true;
            }
        }

        private void dwarfRace_Checked(object sender, RoutedEventArgs e)
        {
            if (anyRace.IsChecked.GetValueOrDefault() == true && dwarfRace.IsChecked.GetValueOrDefault() == true)
            {
                anyRace.IsChecked = false;
            }
            else if (elfRace.IsChecked.GetValueOrDefault() == false && dwarfRace.IsChecked.GetValueOrDefault() == false
               && halflingRace.IsChecked.GetValueOrDefault() == false && humanRace.IsChecked.GetValueOrDefault() == false
               && trollRace.IsChecked.GetValueOrDefault() == false)
            {
                anyRace.IsChecked = true;
            }
        }

        private void humanRace_Checked(object sender, RoutedEventArgs e)
        {
            if (anyRace.IsChecked.GetValueOrDefault() == true && humanRace.IsChecked.GetValueOrDefault() == true)
            {
                anyRace.IsChecked = false;
            }
            else if (elfRace.IsChecked.GetValueOrDefault() == false && dwarfRace.IsChecked.GetValueOrDefault() == false
               && halflingRace.IsChecked.GetValueOrDefault() == false && humanRace.IsChecked.GetValueOrDefault() == false
               && trollRace.IsChecked.GetValueOrDefault() == false)
            {
                anyRace.IsChecked = true;
            }
        }

        private void halflingRace_Checked(object sender, RoutedEventArgs e)
        {
            if (anyRace.IsChecked.GetValueOrDefault() == true && halflingRace.IsChecked.GetValueOrDefault() == true)
            {
                anyRace.IsChecked = false;
            }
            else if (elfRace.IsChecked.GetValueOrDefault() == false && dwarfRace.IsChecked.GetValueOrDefault() == false
               && halflingRace.IsChecked.GetValueOrDefault() == false && humanRace.IsChecked.GetValueOrDefault() == false
               && trollRace.IsChecked.GetValueOrDefault() == false)
            {
                anyRace.IsChecked = true;
            }
        }

        private void trollRace_Checked(object sender, RoutedEventArgs e)
        {
            if (anyRace.IsChecked.GetValueOrDefault() == true && trollRace.IsChecked.GetValueOrDefault() == true)
            {
                anyRace.IsChecked = false;
            }
            else if (elfRace.IsChecked.GetValueOrDefault() == false && dwarfRace.IsChecked.GetValueOrDefault() == false
               && halflingRace.IsChecked.GetValueOrDefault() == false && humanRace.IsChecked.GetValueOrDefault() == false
               && trollRace.IsChecked.GetValueOrDefault() == false)
            {
                anyRace.IsChecked = true;
            }
        }

        private void anyRace_Checked(object sender, RoutedEventArgs e)
        {
            if (anyRace.IsChecked.GetValueOrDefault() == true)
            {
                elfRace.IsChecked = false;
                trollRace.IsChecked = false;
                dwarfRace.IsChecked = false;
                halflingRace.IsChecked = false;
                humanRace.IsChecked = false;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(itemNameText.Text != "Input Name")
            {
                string fileName = "item_"+itemName + ".txt";

                TextWriter tw = new System.IO.StreamWriter(fileName);

                tw.WriteLine("Item name : " + itemName);
                tw.WriteLine("Item type : " + itemType);
                if(itemType == "Weapon")
                {
                    tw.WriteLine("Damage : " + damageValue);
                    tw.WriteLine("Damage type : " + damageType);
                    tw.WriteLine("Weapon sub-type: " + wepSubType);
                }
                else
                {
                    tw.WriteLine("Armor bonus : " + armorBonus);
                }
                tw.WriteLine("Item level : " + itemLevel);
                tw.WriteLine("Required level : " + requiredLevel);
                tw.WriteLine("Binding rule : " + bindingRule);
                tw.WriteLine("Sale value : " + saleValue);

                string classesRequired = "";//get a list of classes that can use this item
                if (anyClass.IsChecked.GetValueOrDefault() == true)
                {
                    classesRequired = " Any class";
                }
                if (rogueClass.IsChecked.GetValueOrDefault() == true)
                {
                    classesRequired = " Rogue ";
                    
                }
                if (warriorClass.IsChecked.GetValueOrDefault()==true)
                {
                    classesRequired = classesRequired + " Warrior ";
                }
                if(wizardClass.IsChecked.GetValueOrDefault()==true)
                {
                    classesRequired = classesRequired + " Wizard ";
                }
                if (clericClass.IsChecked.GetValueOrDefault() == true)
                {
                    classesRequired = classesRequired + " Cleric ";
                }
                if (thiefClass.IsChecked.GetValueOrDefault() == true)
                {
                    classesRequired = classesRequired + " Theif ";
                }
                tw.WriteLine("Class Required :" + classesRequired);

                string racesRequired = "";//get a list of races that can use this item
                if (anyRace.IsChecked.GetValueOrDefault() == true)
                {
                    racesRequired = " Any race";
                }
                if (elfRace.IsChecked.GetValueOrDefault() == true)
                {
                    racesRequired = " Elf ";

                }
                if (dwarfRace.IsChecked.GetValueOrDefault() == true)
                {
                    racesRequired = racesRequired + " Dwarf ";
                }
                if (humanRace.IsChecked.GetValueOrDefault() == true)
                {
                    racesRequired = racesRequired + " Human ";
                }
                if (halflingRace.IsChecked.GetValueOrDefault() == true)
                {
                    racesRequired = racesRequired + " Halfling ";
                }
                if (trollRace.IsChecked.GetValueOrDefault() == true)
                {
                    racesRequired = racesRequired + " Troll ";
                }
                tw.WriteLine("Race Required :" + racesRequired);
                tw.Close();
            }
        }
    }
}
