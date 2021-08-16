using System.ComponentModel.DataAnnotations;

namespace SpaceCats
{
    public class Cat
    {
        [Required]
        public string Name {get; set;}
        [Required]
        [MinLength(2, ErrorMessage = "Breed must be at least 2 characters!")]
        public string Breed {get; set;}
        [Required]
        public string Weapon {get; set;}
        [Required]
        public string Image {get; set;}
        [Required]
        public string MortalEnemy {get; set;}
        [Required]
        [Range(1,9, ErrorMessage = "Number of lives must be between 1 and 9!")]
        public int Lives {get; set;}
    }
}