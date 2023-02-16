using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace CarServiceLibrary.Models.Entities;

public class Users
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Phone(ErrorMessage = "Некорректный формат телефона")]
    [Required(ErrorMessage = "Поле должно быть заполнено!")]
    public string TelephoneNumber { get; set; }

    [MinLength(6, ErrorMessage = "Длина пароля должна быть больше 6-ти символов!")]
    [Required(ErrorMessage = "Поле должно быть заполнено!")]
    public string PasswordUser { get; set; }

    public string RoleUser { get; set; } = "USER";
}