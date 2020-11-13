using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherMonitor.Core.Commands
{
    public class SyncWeatherDataCommand: IRequest<bool>
    {}
}
