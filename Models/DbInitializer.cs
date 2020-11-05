using Application.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Application.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {

                if (!context.Voivodeship.Any())
                {
                    context.Voivodeship.AddRange(
                        new Voivodeship
                        {
                            Name = "dolnośląskie",
                        },
                        new Voivodeship
                        {
                            Name = "kujawsko-pomorskie",
                        },
                        new Voivodeship
                        {
                            Name = "lubelskie",
                        },
                        new Voivodeship
                        {
                            Name = "lubuskie",
                        },
                        new Voivodeship
                        {
                            Name = "łódzkie",
                        },
                        new Voivodeship
                        {
                            Name = "małopolskie",
                        },
                        new Voivodeship
                        {
                            Name = "mazowieckie",
                        },
                        new Voivodeship
                        {
                            Name = "opolskie",
                        },
                        new Voivodeship
                        {
                            Name = "podkarpackie",
                        },
                        new Voivodeship
                        {
                            Name = "podlaskie",
                        },
                        new Voivodeship
                        {
                            Name = "pomorskie",
                        },
                        new Voivodeship
                        {
                            Name = "śląskie",
                        },
                        new Voivodeship
                        {
                            Name = "świętokrzyskie",
                        },
                        new Voivodeship
                        {
                            Name = "warmińsko-mazurskie",
                        },
                        new Voivodeship
                        {
                            Name = "wielkopolskie",
                        },
                        new Voivodeship
                        {
                           Name = "zachodniopomorskie"

                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Task.Any())
                {
                    context.Task.AddRange(
                        new Task
                        {
                            Title = "Stwórz materiał promocyjny",
                            Description = "Tworzenie materiałów promocyjnych rozpocznij od 15 minutowego warsztatu pomysłów. " +
                                          "Koncepcja jest najważniejszą formą kreacji. Następnie zainspiruj się konkurecją, a uzyskany rezultat przedyskutuj ze swoim otoczezniem"
                        },
                        new Task
                        {
                            Title ="Napisz mail do współpracowników",
                            Description = "Stały kontakt jest bardzo ważny. Napisz wiadomość do członków swojego oddziału." +
                                          "Zapytaj jak im minął dzień oraz jak się czują. Sprawdź postępy w realizacji zadań."
                   
                        },
                        new Task
                        {
                            Title = "Przygotuj sprawozdanie tygodnia",
                            Description = "Regularne raportowanie postępów jest bardzo istotne. Stwórz sprawozdanie z działań, " +
                                           "które zostały przez Ciebie podjęte w ciągu mijającego tygodnia. Raport prześlij swojemu przełożonemu."

                        }
                    );
                    context.SaveChanges();

                }



            }
        }
    }
}
