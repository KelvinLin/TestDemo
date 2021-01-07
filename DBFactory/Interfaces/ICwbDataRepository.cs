using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBFactory.Interfaces
{
    public interface ICwbDataRepository
    {
        DataLayerMessage AddWeatherInfos(List<tblWeatherInfo> entities);
    }
}
