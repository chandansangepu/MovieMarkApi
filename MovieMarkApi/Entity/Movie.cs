using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMarkApi.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Access { get; set; } = 1;
        public bool IsWatched { get; set; } = false;
        public DateTime WatchedOn { get; set; } = DateTime.MinValue;
        public bool IsDeleted { get; set; } = false;
    }
}
