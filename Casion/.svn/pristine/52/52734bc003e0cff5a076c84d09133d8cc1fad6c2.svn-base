using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;
using LeaderBoardEntry;
using Domain;
using DataLayer;
using System.Security.Cryptography;


namespace Game.Logik
{
    public class Gamelogik
    {
        MyDataLayer dl = new MyDataLayer();
        public Gamelogik()
        {
            MyDataLayer mdl = new MyDataLayer();
        }
        public List<LeaderboardEntry> FillLeaderBoard()
        {
            List<LeaderboardEntry> leaderboardlist = new List<LeaderboardEntry>();
            List<LoginModel> list = GetUsers();
            int[] scores = new int[5];
            string[] names = new string[5];
            List<int> allscores = new List<int>();
            foreach (var item in list)
                allscores.Add(item.Points);

            allscores.Sort();
            int counter = 0;
            for (int i = allscores.Count - 1; i > allscores.Count - 5; i--, counter++)
                scores[counter] = allscores[i];

            names = FindNameForScore(scores, list);

            for (int i = 0; i < 5; i++)
            {
                LeaderboardEntry l = new LeaderboardEntry(scores[i], names[i]);
                leaderboardlist.Add(l);
            }

            return leaderboardlist;
        }
        private string[] FindNameForScore(int[] scores, List<LoginModel> list)
        {
            string[] strings = new string[5];
            bool canadd = true;
            for (int i = 0; i < 5; i++)
            {

                foreach (var item in list)
                    if (item.Points == scores[i])
                    {
                        canadd = true;
                        for (int y = 0; y < i; y++)
                            if (strings[y] == item.UserName)
                                canadd = false;
                        if (canadd)
                        {
                            strings[i] = item.UserName;
                            break;

                        }
                    }


            }
            return strings;

        }
        public List<LoginModel> GetUsers()
        {
            List<LoginModel> users = new List<LoginModel>();
            foreach (var item in dl.LoadPersons())
            {
                users.Add((LoginModel)item);
            }

            return users;
        }
        public string GetHashed(string password, out string salt)
        {
            // Generiere ein Salt
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            // Hash mit PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32-Byte Hash

                // Kombiniere Salt und Hash für die Speicherung
                salt = Convert.ToBase64String(saltBytes);
                string hashString = Convert.ToBase64String(hash);
                return hashString;
            }


        }
        public static bool VerifyPassword(string password, string salt, string storedHash)
        {
            try
            {
                byte[] saltBytes = Convert.FromBase64String(salt);

                // Rechne den Hash mit dem eingegebenen Passwort neu
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256))
                {
                    byte[] computedHash = pbkdf2.GetBytes(32);

                    // Vergleiche den berechneten Hash mit dem gespeicherten Hash
                    string computedHashString = Convert.ToBase64String(computedHash);
                    return storedHash == computedHashString;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        public string GetSalt(string Username)
        {
            List<LoginModel> list = GetUsers();

            foreach (var item in list)
            {
                if (item.UserName == Username)
                {
                    return item.Salt;
                }
            }
            return null;
        }
        private List<Player> ConvertToPlayerList(List<LoginModel> list)
        {
            List<Player> player = new List<Player>();
            for (int i = 0; i < list.Count; i++)
            {
                player.Add((Player)list[i]);
            }
            return player;
        }
        public void AddNewUser(List<LoginModel> list, LoginModel model)
        {
            if (model.Age >= 18)
            {
                string salt = "";
                model.Password = GetHashed(model.Password, out salt);
                model.Salt = salt;
                list.Add(model);
            }
            dl.SavePersons(ConvertToPlayerList(list));
        }
        public void SavePerson(List<LoginModel> list) 
        {
            dl.SavePersons(ConvertToPlayerList(list));
        }
        private int GetIntForName(string numbers) 
        {
            int nums = 0;
            
                switch (numbers)
                {
                    case "Two":
                        nums = 2;
                        break;
                    case "Three":
                        nums = 3;
                        break;
                    case "Four":
                        nums = 4;
                        break;
                    case "Five":
                        nums = 5;
                        break;
                    case "Six":
                        nums = 6;
                        break;
                    case "Seven":
                        nums = 7;
                        break;
                    case "Eight":
                        nums = 8;
                        break;
                    case "Nine":
                        nums = 9;
                        break;
                    case "Ten":
                        nums = 10;
                        break;
                    case "Jack":
                        nums = 11;
                        break;
                    case "Queen":
                        nums = 12;
                        break;
                    case "King":
                        nums = 13;
                        break;
                    case "Ace":
                        nums = 14;
                        break;
                
            }
            return nums;
        }
        public string GetPoints(string[] cards, int mult) 
        {
            string[] seperatededcard = new string[2];
            int[] values = new int[5];
            string[] icons = new string[5];

            for (int i = 0; i < cards.Length; i++)
            {
                seperatededcard = cards[i].Split('-');
                values[i] = GetIntForName(seperatededcard[1]);
                icons[i] = seperatededcard[0];
            }
            if (IsRoyalFlush(values, icons))
                return  10000 * mult + "-Royal Flush";
            else if (IsStreaightFlush(values, icons))
                return 500 * mult + "-Straight Flush";
            else if (IsQuad(values))
                return 200 * mult + "-Quad";
            else if (IsFlush(icons))
                return 150 * mult + "-Flush";
            else if (IsStreaight(values))
                return 100 * mult + "-Straight";
            else if (IsTripple(values))
                return 30 * mult + "-Tripple";
            else if (IsTwoPair(values))
                return 20 * mult + "-Two Pair";
            else if (IsPair(values))
                return 10 * mult + "-Pair";
            else
                return 0 + "-Loss";


        }
        public int SperatePointsFromString(string points) 
        {
            string[] value = points.Split('-');
            return Convert.ToInt32(value[0]);
        }

        #region Poker Hands
        public bool IsPair(int[] values)
        {
            for (int i = 0; i < 3; i++)
                if (values[i] == values[i + 1])
                    return true;
            return false;
        }
        public bool IsTripple(int[] values)
        {

            for (int i = 0; i < 2; i++)
                if ((values[i] == values[i + 1]) && (values[i] == values[i + 2]))
                    return true;
            return false;
        }
        public bool IsTwoPair(int[] values)
        {
            var groups = values.GroupBy(x => x)
                          .Where(g => g.Count() == 2)
                          .ToList();

            return groups.Count == 2;
        }
        public bool IsQuad(int[] values)
        {
            for (int i = 0; i < 1; i++)
                if ((values[i] == values[i + 1]) && (values[i] == values[i + 2]) && (values[i] == values[i + 3]))
                    return true;
            return false;
        }
        public bool IsFlush(string[] icons)
        {
            if (icons[0] == icons[1] && icons[0] == icons[2] && icons[0] == icons[3] && icons[0] == icons[4])
                return true;
            return false;
        }
        public bool IsStreaight(int[] cards)
        {
            QuickSort(cards, 0, cards.Length - 1);

            for (int i = 1; i < 5; i++)
            {
                if (cards[i - 1] - 1 != cards[i])
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsStreaightFlush(int[] values, string[] icons)
        {
            if (IsFlush(icons) && IsStreaight(values))
            {
                return true;
            }
            return false;
        }
        public bool IsRoyalFlush(int[] values, string[] icons)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
                for (int x = 1; x < 5; x++)
                    if (values[i] == values[x])
                        return false;
            for (int i = 0; i < 5; i++)
                sum += values[i];



            if (sum == 50)
                if (icons[0] == icons[1] && icons[0] == icons[2] && icons[0] == icons[4] && icons[0] == icons[5])
                    return true;

            return false;
        }
        #endregion

        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
            (array[i + 1], array[right]) = (array[right], array[i + 1]);
            return i + 1;
        }

    }
}
