using GOT.Models;
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
using GOT.Services.Abstract;
using GOT.Services;
using Newtonsoft.Json;

namespace GOT.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Character[] Characters { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            FillListBox();
        }

        private void FillListBox()
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);

            string json = downloader.DownloadDataJson("https://api.got.show/api/book/characters");
            Characters = JsonConvert.DeserializeObject<Character[]>(json);

            var charactersName = Characters.Select(c => c.Name);

            charactersList.ItemsSource = charactersName;
        }

        private void CharacterNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var charactersName = Characters.Select(c => c.Name);
            var sortedCharacters = charactersName.Where(c => c.ToLower().Contains(characterNameTextBox.Text.ToLower()));

            charactersList.ItemsSource = sortedCharacters;
        }

        private void CharactersListMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCharacterName = charactersList.SelectedItem.ToString();

            var selectedCharacter = Characters.FirstOrDefault(c => c.Name == selectedCharacterName);

            CharacterWindow characterWindow = new CharacterWindow(selectedCharacter);
            characterWindow.ShowDialog();
        }
    }
}
