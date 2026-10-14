using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Class_36
{
    private readonly string field_147;

    private readonly HttpClient field_148;

    public Class_36()
    {
        field_147 =
            "https://script.google.com/macros/s/AKfycbzNL5cQVIgPZqm7kYcVIwoshzyYl8Q41fOV3Rgm6BmSEL3doCqpA0NQwwGB9QnCn9Q_/exec";
        var httpClient = new HttpClient();
        var var_01 = TimeSpan.FromSeconds(1000.0);
        httpClient.Timeout = var_01;
        field_148 = httpClient;
    }

    public async Task<Class_38> method_237(Class_37 arg_01)
    {
        try
        {
            var content = JsonConvert.SerializeObject(arg_01);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            field_148.DefaultRequestHeaders.Accept.Clear();
            field_148.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpResponseMessage = await field_148.PostAsync(field_147, stringContent);
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new HttpRequestException(string.Format(
                    arg1: await httpResponseMessage.Content.ReadAsStringAsync(),
                    format: "HTTP Error: {0}. Content: {1}", arg0: httpResponseMessage.StatusCode));

            return JsonConvert.DeserializeObject<Class_38>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        catch (TaskCanceledException)
        {
            throw new TimeoutException("The request timed out");
        }
        catch (Exception ex2)
        {
            var ex3 = ex2;
            throw new Exception("API call failed: " + ex3.Message, ex3);
        }
    }

    public async Task<Class_41> method_238(Class_42 arg_01)
    {
        try
        {
            var content = JsonConvert.SerializeObject(arg_01);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            field_148.DefaultRequestHeaders.Accept.Clear();
            field_148.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpResponseMessage = await field_148.PostAsync(field_147, stringContent);
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new HttpRequestException(string.Format(
                    arg1: await httpResponseMessage.Content.ReadAsStringAsync(),
                    format: "HTTP Error: {0}. Content: {1}", arg0: httpResponseMessage.StatusCode));

            return JsonConvert.DeserializeObject<Class_41>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        catch (TaskCanceledException)
        {
            throw new TimeoutException("The request timed out");
        }
        catch (Exception ex2)
        {
            var ex3 = ex2;
            throw new Exception("API call failed: " + ex3.Message, ex3);
        }
    }

    public class Class_37
    {
        [JsonProperty("email")]
        [field: CompilerGenerated]
        public string Email { [CompilerGenerated] get; [CompilerGenerated] set; }

        [JsonProperty("password")]
        [field: CompilerGenerated]
        public string Password { [CompilerGenerated] get; [CompilerGenerated] set; }
    }

    public class Class_38
    {
        [JsonProperty("success")]
        [field: CompilerGenerated]
        public bool Success { [CompilerGenerated] get; [CompilerGenerated] set; }

        [JsonProperty("message")]
        [field: CompilerGenerated]
        public string Message { [CompilerGenerated] get; [CompilerGenerated] set; }
    }

    public class Class_40
    {
        [JsonProperty("email")]
        [field: CompilerGenerated]
        public string Email { [CompilerGenerated] get; [CompilerGenerated] set; }

        [JsonProperty("password")]
        [field: CompilerGenerated]
        public string Password { [CompilerGenerated] get; [CompilerGenerated] set; }

        [JsonProperty("criticaldata")]
        [field: CompilerGenerated]
        public string Criticaldata64 { [CompilerGenerated] get; [CompilerGenerated] set; }
    }

    public class Class_41
    {
        [JsonProperty("success")]
        [field: CompilerGenerated]
        public bool Success { [CompilerGenerated] get; [CompilerGenerated] set; }

        [JsonProperty("balance")]
        [field: CompilerGenerated]
        public decimal Balance { [CompilerGenerated] get; [CompilerGenerated] set; }

        [JsonProperty("data")]
        [field: CompilerGenerated]
        public string Data { [CompilerGenerated] get; [CompilerGenerated] set; }
    }

    public class Class_42
    {
        [JsonProperty("requestinfoB64")]
        [field: CompilerGenerated]
        public string RequestinfoB64 { [CompilerGenerated] get; [CompilerGenerated] set; }
    }
}