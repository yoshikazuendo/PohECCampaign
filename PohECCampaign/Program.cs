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
				Console.WriteLine(Search(itemPrices, campaignPrice));
			}
		}

		static int Search(int[] itemPrices, int campaignPrice)
		{
			int bestPrice = 0;
			// キャンペーン価格を超えている商品を除く。 
			var targetItems = itemPrices.Where(it => it <= campaignPrice).ToArray();

			for (int i = 0; i < targetItems.Length; i++) {
				for (int j = i + 1; j < targetItems.Length; j++) {
					int totalPrice = targetItems[i] + targetItems[j];
					if (IsBestPrice(totalPrice, bestPrice, campaignPrice)) {
						bestPrice = totalPrice;
						// キャンペーン価格だったら返す。 
						if (bestPrice == campaignPrice) return bestPrice;
					}
				}
			}

			return bestPrice;
		}

		static bool IsBestPrice(int targetPrice, int bestPrice, int campaignPrice)
		{
			return bestPrice <= targetPrice && targetPrice <= campaignPrice;
		}
	}
}