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
using System.Windows.Shapes;
using GOT.Models;

namespace GOT.UI
{
    /// <summary>
    /// Логика взаимодействия для CharacterWindow.xaml
    /// </summary>
    public partial class CharacterWindow : Window
    {
        public CharacterWindow(Character character)
        {
            InitializeComponent();

            nameTextBlock.Text = "Name: " + character.Name;
            genderTextBlock.Text = "Gender: " + character.Gender;
            houseTextBlock.Text = "House: " + character.House;
            birthTextBlock.Text = "Birth year: " + character.Birth;
            aliveTextBlock.Text = "Is alive: " + character.IsAlive;
            createdAtTextBlock.Text = "Created at: " + character.CreatedAt;
        }
    }
}
