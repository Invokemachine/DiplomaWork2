using System;
using System.Collections.Generic;

#nullable disable

namespace ChessBoard
{
    public partial class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int? ClassicalChessFideElo { get; set; }
        public int? RapidChessFideElo { get; set; }
        public int? BlitzChessFideElo { get; set; }
        public int? BulletChessFideElo { get; set; }
        public string Picture { get; set; }
    }
}
