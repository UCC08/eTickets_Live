﻿using eTickets_Live.Data.Base;
using eTickets_Live.Data.ViewModels;
using eTickets_Live.Models;

namespace eTickets_Live.Data.Interfaces
{
    // Aslında kullanılacak metodları içerecek fakat bunları kendi üzerinden değil bir interface üzerinden kullacak...
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Movie GetMovieById(int id);

        // Create ekranında görüntülenek olan dropdown seçimleri için ayrı bir model üzerinden yapılması gerekiyor.
        NewMovieDropdownsVM GetNewMovieDropdownsValues();
    }
}
