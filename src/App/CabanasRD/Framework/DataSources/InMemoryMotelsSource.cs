using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabanasRD.Data.Motels;
using CabanasRD.Domain.Motels;

namespace CabanasRD.Framework.DataSources
{
    public class InMemoryMotelsSource: IMotelsSource
    {
        public async Task<IReadOnlyList<Motel>> GetAll()
        {
            await Task.Delay(1000);
            return new List<Motel>
            {
                    new Motel{
                        Id = 2,
                        Latitude = 18.4895593,
                        Longitude = -69.8247819,
                        Name = "Motel Cuarto Frío",
                        Images = new List<MotelImage>{
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            },
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            },
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            }
                        },
                        Phones = new List<MotelPhone>{
                            new MotelPhone{ Number = "809-000-0000"},
                            new MotelPhone{ Number = "829-000-0000"},
                            new MotelPhone{ Number = "849-000-0000"}

                        },
                        Services = new List<MotelService>{
                            new MotelService {
                                Name = "Normal",
                                Price = 725.00
                            },
                            new MotelService {
                                Name = "Ejecutiva",
                                Price = 925.00
                            },
                            new MotelService {
                                Name = "Vice Presidencial",
                                Price = 1050.00
                            },
                            new MotelService {
                                Name = "Presidencial",
                                Price = 1350.00
                            }
                        }
                    },
                    new Motel{
                        Id = 3,
                        Latitude = 18.502296,
                        Longitude = -69.864370,
                        Name = "El Real Placer",
                        Images = new List<MotelImage>{
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            },
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            },
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            }
                        },
                        Phones = new List<MotelPhone>{
                            new MotelPhone{ Number = "809-000-0000"},
                            new MotelPhone{ Number = "829-000-0000"},
                            new MotelPhone{ Number = "849-000-0000"}

                        },
                        Services = new List<MotelService>{
                            new MotelService {
                                Name = "Normal",
                                Price = 725.00
                            },
                            new MotelService {
                                Name = "Ejecutiva",
                                Price = 925.00
                            },
                            new MotelService {
                                Name = "Vice Presidencial",
                                Price = 1050.00
                            },
                            new MotelService {
                                Name = "Presidencial",
                                Price = 1350.00
                            }
                        }
                    },
                    new Motel{
                        Id = 4,
                        Latitude = 18.492438,
                        Longitude = -69.907610,
                        Name = "La Escuelita",
                        Images = new List<MotelImage>{
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            },
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            },
                            new MotelImage {
                                Url = "https://c2.peakpx.com/wallpaper/604/823/790/castle-fortress-defense-architecture-wallpaper-preview.jpg"
                            },
                            new MotelImage {
                                Url = "https://media.npr.org/assets/img/2015/08/15/robin1-8aea039fd0710bd0c8549c19abab4085e0e3024c-s800-c85.jpg"
                            }
                        },
                        Phones = new List<MotelPhone>{
                            new MotelPhone{ Number = "809-000-0000"},
                            new MotelPhone{ Number = "829-000-0000"},
                            new MotelPhone{ Number = "849-000-0000"}

                        },
                        Services = new List<MotelService>{
                            new MotelService {
                                Name = "Normal",
                                Price = 725.00
                            },
                            new MotelService {
                                Name = "Ejecutiva",
                                Price = 925.00
                            },
                            new MotelService {
                                Name = "Vice Presidencial",
                                Price = 1050.00
                            },
                            new MotelService {
                                Name = "Presidencial",
                                Price = 1350.00
                            }
                        }
                    }
            };
        }
    }
}
