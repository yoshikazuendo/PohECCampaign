using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PohECCampaign
{
	class Program
	{
		static void Main(string[] args)
		{
			var counts = Console.ReadLine().Trim().Split(' ');
			int itemCount = int.Parse(counts[0]);
			var itemPrices = new int[itemCount];
			for (int i = 0; i < itemCount; i++) {
				itemPrices[i] = int.Parse(Console.ReadLine().Trim());
			}

			int campaignDay = int.Parse(counts[1]);
			var campaignPrices = new int[campaignDay];
			for (int i = 0; i < campaignDay; i++) {
				campaignPrices[i] = int.Parse(Console.ReadLine().Trim());
			}

			foreach (var campaignPrice in campaignPrices) {
				int bestPrice = 0;

				for (int i = 0; i < itemCount; i++) {
					for (int j = i + 1; j < itemCount; j++) {
						int totalPrice = itemPrices[i] + itemPrices[j];
						if (bestPrice <= totalPrice && totalPrice <= campaignPrice) {
							bestPrice = totalPrice;
						}
					}
				}

				Console.WriteLine(bestPrice);
			}
		}
	}
}