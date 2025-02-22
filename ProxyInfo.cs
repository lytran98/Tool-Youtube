namespace YoutubeMultiManual
{
    public class ProxyInfo
    {
        public string? IP { get; set; }
        public int Port { get; set; }
        public string? Protocol { get; set; } // HTTP, HTTPS, SOCKS4, SOCKS5

        public string ToCommandArg()
        {
            // Mặc định "http" nếu protocol null
            string proto = (Protocol ?? "http").ToLower();
            return $"{proto}://{IP}:{Port}";
        }
    }
}
