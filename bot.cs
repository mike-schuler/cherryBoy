using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
	public class Bot
	{
		public DiscordClient Client { get; private set; }
		public CommandsNextExtension CommandsNext { get; private set; }
		public async Task RunAsync()
		{
			var json = string.Empty;
			using(var fs = File.OpenRead("C:\\Users\\mschu\\source\\repos\\cherryBoy\\config.json"))
			{
				using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
					json = await sr.ReadToEndAsync().ConfigureAwait(false);
			}
			var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
			var config = new DiscordConfiguration
			{
				Token = configJson.Token,
				TokenType = TokenType.Bot,
				Intents = DiscordIntents.AllUnprivileged,
                AutoReconnect = true,
				MinimumLogLevel = LogLevel.Debug,


			};

			Client = new DiscordClient(config);




            var commandsConfig = new CommandsNextConfiguration
			{
				StringPrefixes = new string[] {configJson.Prefix},
				EnableMentionPrefix = true,
				EnableDms = false

			};
			CommandsNext = Client.UseCommandsNext(commandsConfig);

			await Client.ConnectAsync();

			await Task.Delay(-1);

		}

		private Task OnClientReady(ReadyEventArgs e)
		{
			Console.WriteLine("Bot Online.");

			return null;
		}
	}
}
