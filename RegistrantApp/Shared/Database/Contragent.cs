﻿using System.ComponentModel.DataAnnotations;

namespace RegistrantApp.Shared.Database;

public class Contragent
{
    [Key] public long ContragentID { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}