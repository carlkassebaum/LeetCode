using System.Collections.Generic;

namespace ShoppingOffers
{
    public class Solution
    {
        private bool CanApplyPromotion(IList<int> promotion, IList<int> needs)
        {
            for (var i = 0; i < needs.Count; i++)
            {
                if (promotion[i] > needs[i])
                {
                    return false;
                }
            }

            return true;
        }

        private IList<int> GetNewNeedsUsingPromotion(IList<int> promotion, IList<int> needs)
        {
            var newNeeds = new int[needs.Count];
            for (var i = 0; i < needs.Count; i++)
            {
                newNeeds[i] = needs[i] - promotion[i];
            }

            return newNeeds;

        }

        private int Dot(IList<int> a, IList<int> b)
        {
            int sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i] * b[i];
            }
            return sum;
        }

        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            var memory = new Dictionary<IList<int>, int>();

            return ShoppingOffers(price, special, needs, memory);
        }

        private int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs, Dictionary<IList<int>, int> memory)
        {
            if (memory.ContainsKey(needs))
            {
                return memory[needs];
            }

            var promotionApplied = false;
            var minPromotionCost = 0;

            for (var i = 0; i < special.Count; i++)
            {
                var currentPromotion = special[i];

                if (CanApplyPromotion(currentPromotion, needs))
                {
                    var newNeeds = GetNewNeedsUsingPromotion(special[i], needs);
                    var costWithPromotion = currentPromotion[currentPromotion.Count - 1] + ShoppingOffers(price, special, newNeeds, memory);

                    if (!promotionApplied || costWithPromotion < minPromotionCost)
                    {
                        promotionApplied = true;
                        minPromotionCost = costWithPromotion;
                    }
                }
            }
            
            if (!promotionApplied)
            {
                minPromotionCost = Dot(needs, price);
            }

            memory[needs] = minPromotionCost;
            return minPromotionCost;
        }
    }
}
