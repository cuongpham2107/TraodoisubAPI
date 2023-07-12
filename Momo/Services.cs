using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo
{

    public class Services
    {
        static ConfigService _configService = ConfigManager<ConfigService>.Instance.Config;
        public Services() { }
        public HttpClient client { get; set; } = new HttpClient();
        /// <summary>
        /// Đặt cấu hình nick
        /// </summary>
        /// <param name="fields">tiktok_run</param>
        /// <param name="id">ID tiktok dạng số hoặc username tiktok</param>
        /// <returns></returns>
        public async Task SettingConfig(string fields = "",string id = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_configService.CurrentUrl}/?fields={fields}&id={id}&access_token={_configService.Token}");
            var response = await this.client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
        /// <summary>
        /// Lấy danh sách nhiệm vụ 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields">Bao gồm: tiktok_like, tiktok_follow, tiktok_comment</param>
        /// <returns></returns>
        public async Task<T> GetList<T>(string fields = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_configService.CurrentUrl}/?fields={fields}&access_token={_configService.Token}");
                //"");
            var response = await this.client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadAsStringAsync();
            T? data = JsonConvert.DeserializeObject<T>(results);
            return data;
        }
        /// <summary>
        /// Gửi duyệt nhiệm vụ
        /// </summary>
        /// <param name="type">Loại nhiệm vụ "TIKTOK_LIKE_CACHE, TIKTOK_FOLLOW_CACHE,FACEBOOK_LIKE_CACHE, FACEBOOK_FOLLOW_CACHE,..."</param>
        /// <param name="id">ID job đã làm</param>
        /// <returns></returns>
        public async Task SubmitTask(string type = "", string id = "")
        {            
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_configService.CurrentUrl}/coin/?type={type}&id={id}&access_token={_configService.Token}");
            var response = await this.client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Extensions.WriteLine(await response.Content.ReadAsStringAsync(),ConsoleColor.Blue);
        }
        /// <summary>
        /// Đối với nhiệm vụ like và follow, khi số nhiệm vụ gửi duyệt trên web lớn hơn 8 thì sẽ được nhận xu!
        /// Hãy nhận xu khi nhiệm vụ gửi duyệt đạt từ 8 - 15 nhiệm vụ để tránh lỗi.
        /// Đối với nhiệm vụ comment thì nhận sau khi comment khoảng 10 giây, vì tiktok kiểm duyệt nội dung comment
        /// </summary>
        /// <param name="type">Bao gồm: TIKTOK_LIKE, TIKTOK_FOLLOW, TIKTOK_COMMENT</param>
        /// <param name="id">Đối với fields là TIKTOK_COMMENT: là id job đã làm, Đối với fields là TIKTOK_FOLLOW: cố định giá trị là: TIKTOK_FOLLOW_API, Đối với fields là TIKTOK_LIKE: cố định giá trị là: TIKTOK_LIKE_API</param>
        /// <returns></returns>
        public async Task GetCoins(string type = "", string id = "TIKTOK_FOLLOW_API")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_configService.CurrentUrl}/coin/?type={type}&id={id}&access_token={_configService.Token}"
                //"https://traodoisub.com/api/coin/?type=TIKTOK_FOLLOW&id=TIKTOK_FOLLOW_API&access_token={{TDS_token}}"
                );
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

    }
}
