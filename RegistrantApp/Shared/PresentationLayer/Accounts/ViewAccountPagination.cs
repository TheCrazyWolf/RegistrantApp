﻿using RegistrantApp.Shared.PresentationLayer.Pagination;

namespace RegistrantApp.Shared.PresentationLayer.Accounts;

public class ViewAccountPagination : PaginationBase
{
    public ICollection<ViewAccount> Accounts { get; set; } = new List<ViewAccount>();
}