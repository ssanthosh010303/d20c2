/*
 * Author: Sakthi Santhosh
 * Created on: 09/05/2024
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLibrary.Models;

public class Request
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string RequestText { get; set; }

    public int RaisedById { get; set; }

    [ForeignKey("RaisedById")]
    public Employee RaisedBy { get; set; }

    public string Status { get; set; }

    public int? ClosedById { get; set; }

    [ForeignKey("ClosedById")]
    public Employee ClosedBy { get; set; }

    public DateTime RaisedDate { get; set; }

    public DateTime? ClosedDate { get; set; }

    public override string ToString()
    {
        string data = "";

        data += "+----------------------------------------+";
        data += "| Request                                |";
        data += "+----------------------------------------+";
        data += $"  ID:      ${Id}                        ";
        data += $"  Request: ${RequestText}               ";
        data += $"  Status:  ${Status}                    ";
        data += "+----------------------------------------+";

        return data;

    }
}
