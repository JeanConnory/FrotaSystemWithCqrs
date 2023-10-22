using FrotaApp.Application.Input.Commands.VehicleContext;
using FrotaApp.Application.Input.Receivers.Interfaces;
using FrotaApp.Domain.Entities;

namespace FrotaApp.Application.Input.Receivers
{
    public class InsertVehicleReceiver : IReceiver<VehicleCommand, State>
    {
        public State Action(VehicleCommand command)
        {
            var vehicle = new VehicleEntity(command.Name, command.Color, command.ModelYear, command.CategoryId, command.Price, command.Type);
            
            vehicle.IsValid();

            throw new NotImplementedException();
        }
    }
}
