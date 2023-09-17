#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ChefsnDishes.Models;


public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    [Display(Name = "First Name:")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name:")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    [PastDate(ErrorMessage = "Birth Date must've happened")]
    public DateTime Birthday { get; set; }
    public int Age
    {
        get { return DateTime.Now.Year - Birthday.Year; }
    }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Dish> Dishes { get; set;} = new();


    
}

    

  




public class PastDateAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid (object value, ValidationContext validationContext)
    {
        if (((DateTime)value) > DateTime.Now)
        {
            return new ValidationResult ("Birth Date must've happened");
        } else {
            return ValidationResult.Success;
        }
    }
}