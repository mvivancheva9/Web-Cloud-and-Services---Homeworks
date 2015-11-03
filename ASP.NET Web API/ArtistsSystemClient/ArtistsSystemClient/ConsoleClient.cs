namespace ArtistsSystemClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using JsonModels;
    using Newtonsoft.Json;

    public class ConsoleClient
    {
        public static void Main()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<string> requestArtists = GetResponseString(client);
            var artistsAsJson = requestArtists.Result;
            var artists = JsonConvert.DeserializeObject<IEnumerable<ArtistsResponseModel>>(artistsAsJson);
            PrintArists(artists);

            HttpClient xmlClient = new HttpClient();

            xmlClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            Task<string> requestXmlArtists = GetResponseString(xmlClient);
            var artistsAsXml = requestXmlArtists.Result;
            Console.WriteLine(artistsAsXml);
        }

        private static void PrintArists(IEnumerable<ArtistsResponseModel> artists)
        {
            Console.WriteLine("Artists");
            foreach (var artist in artists)
            {
                Console.WriteLine("Artist Name: {0}, birthDate: {1}", artist.Name, artist.DateOfBirth);
                if (artist.Albums.Count() > 0)
                {
                    foreach (var album in artist.Albums)
                    {
                        Console.WriteLine("Album: {0}", album.Title);
                        if (album.Songs.Count() > 0)
                        {
                            foreach (var song in album.Songs)
                            {
                                Console.WriteLine("song: {0} - year: {1} - duration: {2}, - genre: {3}", song.Title, song.Year, song.DurationInSeconds, song.Genre);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No songs!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No albums!");
                }
            }
        }

        public static async Task<string> GetResponseString(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync(new Uri("http://localhost:2952/api/artists"));
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
    }
}
