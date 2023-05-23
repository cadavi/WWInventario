using WWInventario.Models;
using WWInventario.Models;

namespace WWInventario.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();

                //Dispositivos
                if (!context.Dispositivos.Any())
                {
                    context.Dispositivos.AddRange(new List<Dispositivo>()
                    {
                        new Dispositivo()
                        {
                           Tipo = "Laptop"
                        },
                        new Dispositivo()
                        {
                           Tipo = "Celular"
                        },
                        new Dispositivo()
                        {
                           Tipo = "Monitor"
                        },
                        new Dispositivo()
                        {
                            Tipo = "Teclado"
                        },

                    });
                    context.SaveChanges();
                }

                //Estado Equipos
                if(!context.EstadoEquipos.Any())
                {
                    context.EstadoEquipos.AddRange(new List<EstadoEquipo>()
                    {
                        new EstadoEquipo()
                        {
                            Estado = "Disponible",
                            FechaCreacion = DateTime.Now,
                            FechaModificacion = DateTime.Now
                        },
                        new EstadoEquipo()
                        {
                            Estado = "Ocupado",
                            FechaCreacion = DateTime.Now,
                            FechaModificacion = DateTime.Now
                        },
                        new EstadoEquipo()
                        {
                            Estado = "Reparación",
                            FechaCreacion = DateTime.Now,
                            FechaModificacion = DateTime.Now
                        },
                        new EstadoEquipo()
                        {
                            Estado = "Obsoleto",
                            FechaCreacion = DateTime.Now,
                            FechaModificacion = DateTime.Now
                        },
                    });
                    context.SaveChanges(true);
                }

                if(!context.Companias.Any())
                {
                    context.Companias.AddRange(new List<Compania>()
                    {
                        new Compania()
                        {
                            Nombre = "WORLDWIDE SEGUROS",
                            Pais = "REPÚBLICA DOMINICANA",
                            LogoPath = string.Empty
                        },
                        new Compania()
                        {
                            Nombre = "WORLDWIDE MEDICAL ASSURANCE, LTD CORP.",
                            Pais = "PANAMÁ",
                            LogoPath= string.Empty
                        },
                    });
                    context.SaveChanges();
                }

                //Sucursales
                if(!context.Sucursales.Any())
                {
                    context.Sucursales.AddRange(new List<Sucursal>()
                    {
                        new Sucursal()
                        {
                            Nombre = "DISTRITO NACIONAL",
                            Direccion = "AV. ABRAHAM LINCOLN #295, EDIF. CARIBALICO, 5TO. PISO, LA JULIA, SANTO DOMINGO. TEL. (809) 508-7447, FAX (809) 534-7626",
                            CompaniaId = 1
                        },
                        new Sucursal()
                        {
                            Nombre = "CIUDAD DE PANAMÁ",
                            Direccion = "CALLE 50, EDIF. GLOBAL BANK, SUITE 2701, PANAMÁ",
                            CompaniaId = 2
                        },
                    });
                    context.SaveChanges();
                }

                //Proveedores
                if(!context.Proveedores.Any())
                {
                    context.AddRange(new List<Proveedor>()
                    {
                        new Proveedor()
                        {
                            RNC = "FGGGGAAA",
                            Nombre = "CECOMSA",
                            Direccion = "Av. Rómulo Betancourt 331",
                            EmailPrincipal = "CECOMSA@GMAIL.COM.DO",
                            EmailSecundario = "CECOMSA2@GMAIL.COM.DO",
                            TelefonoPrincipal = "8095327026",
                            TelefonoSecundario = "8095327020",
                        },

                        new Proveedor()
                        {
                            RNC = "MDFAHAHHH",
                            Nombre = "OMEGA TECH",
                            Direccion = "Av. John F. Kennedy, Km 8 1/2 Los Prados, Santo Domingo, Rep. Dom.",
                            EmailPrincipal = "OMEGATECH@GMAIL.COM.DO",
                            EmailSecundario = "OMEGATECH2@GMAIL.COM.DO",
                            TelefonoPrincipal = "8096834343",
                            TelefonoSecundario = "8096834328",
                        },

                        new Proveedor()
                        {
                            RNC = "FRDSTJKKLK",
                            Nombre = "OAS COMPUTER",
                            Direccion = "Av. Maximo gomez Plaza gazcue 2do Nivel",
                            EmailPrincipal = "OASCOMPUTER@GMAIL.COM.DO",
                            EmailSecundario = "OASCOMPUTER2@GMAIL.COM.DO",
                            TelefonoPrincipal = "8092382020",
                            TelefonoSecundario = "8092382025",
                        },
                    });
                    context.SaveChanges();
                }

                //Equipos
                if(!context.Equipos.Any())
                {
                    context.Equipos.AddRange(new List<Equipo>()
                    {
                       new Equipo()
                       {
                           SerialNo = "AAAQQS2521",
                           Modelo = "E14",
                           Marca = "LENOVO",
                           FechaCompra = DateTime.Now,
                           FechaInicioGarantia = DateTime.Now.AddYears(2),
                           FechaFinGarantia = DateTime.Now.AddYears(3),
                           FechaAsignacion = null,
                           DispositivoId = 1,
                           UsuarioResponsableId = null,
                           EstadoEquipoId = 1
                       },
                       new Equipo()
                       {
                           SerialNo = "KHHOSS1248YTTT",
                           Modelo = "24INCH",
                           Marca = "SAMSUNG",
                           FechaCompra= DateTime.Now,
                           FechaInicioGarantia = DateTime.Now.AddYears(3),
                           FechaFinGarantia= DateTime.Now.AddYears(4),
                           FechaAsignacion = null,
                           DispositivoId = 3,
                           UsuarioResponsableId = null,
                           EstadoEquipoId = 1
                       },
                       new Equipo()
                       {
                           SerialNo = "MGSFT254KK8454",
                           Modelo = "Iphone 6S PLUS",
                           Marca = "APPLE",
                           FechaCompra = DateTime.Now,
                           FechaInicioGarantia = DateTime.Now.AddMonths(20),
                           FechaFinGarantia = DateTime.Now.AddMonths(21),
                           FechaAsignacion = null,
                           DispositivoId = 1,
                           UsuarioResponsableId = null,
                           EstadoEquipoId = 1
                       },
                       new Equipo()
                       {
                           SerialNo = "GFGG787HHGH",
                           Modelo = "6GHZ",
                           Marca = "DELL",
                           FechaCompra = DateTime.Now,
                           FechaInicioGarantia = DateTime.Now.AddMonths(18),
                           FechaFinGarantia = DateTime.Now.AddMonths(19),
                           FechaAsignacion = null,
                           DispositivoId = 4,
                           UsuarioResponsableId = null,
                           EstadoEquipoId = 1
                       },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
