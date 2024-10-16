using System;
using GraphQLProject.Interfaces;
using GraphQLProject.Data;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
	public class ReservationRepository : IReservationRepository
	{
        private GraphQLDbContext graphQLDbContext;

        public ReservationRepository(GraphQLDbContext graphQLDbContext)
        {
            this.graphQLDbContext = graphQLDbContext;
        }

        Reservation IReservationRepository.AddReservation(Reservation reservation)
        {
            graphQLDbContext.Reservations.Add(reservation);
            graphQLDbContext.SaveChanges();
            return reservation;
        }

        List<Reservation> IReservationRepository.GetReservations()
        {
            return graphQLDbContext.Reservations.ToList();
        }
    }
}

