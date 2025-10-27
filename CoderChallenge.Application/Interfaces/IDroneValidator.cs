using CoderChallenge.Arguments.Arguments.Drone;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Interfaces;

public interface IDroneValidator
{
    void ValidarDroneExistente(DroneEntity drone);
    void ValidarInputDrone(InputDrone drone);
}