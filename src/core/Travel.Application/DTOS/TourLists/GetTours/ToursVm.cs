using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.DTOS.Tour;

namespace Travel.Application.DTOS.TourLists.GetTours
{
    public class ToursVm
    {
        public IList<TourListDto> Lists { get; set; }
    }
}
