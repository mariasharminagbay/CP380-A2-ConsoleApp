using System;

namespace RatingAdjustment.Services
{
    /** Service calculating a star rating accounting for the number of reviews
     * 
     */
    public class RatingAdjustmentService
    {
        // TODO: Replace this file with the one from Part A!
        const double MAX_STARS = 5.0;  // Likert scale
        const double Z = 1.96; // 95% confidence interval

        double _q;
        double _percent_positive;

        /* Percentage of positive reviews */
        void SetPercentPositive(double stars)
        {
            // TODO: Implement this!
            _percent_positive = stars / MAX_STARS; //if the stars given is 0 then _percent_positive will be 0 and if the stars given isare 5 then _percent_positive will be 1
        }

        /* Calculate "Q" 
         */
        void SetQ(double number_of_ratings)
        {
            // TODO: Implement this!
            _q = Z * Math.Sqrt(((_percent_positive * (1 - _percent_positive)) + ((Z * Z) / (4 * number_of_ratings))) / number_of_ratings);
        }

        /* Adjusted lower bound */

        public double Adjust(double stars, double number_of_ratings)
        {
            // TODO: Implement this!
            SetPercentPositive(stars);
            SetQ(number_of_ratings);
            double _lowerBound = ((_percent_positive + ((Z * Z) / (2.0 * number_of_ratings)) - _q) / (1.0 + ((Z * Z) / number_of_ratings)));
            double _lb = _lowerBound * MAX_STARS;
            if (stars <= MAX_STARS)
            {
                if (_lb <= MAX_STARS)
                {
                    return _lb;
                }
                else
                {
                    return stars;
                }
            }
            return 0.0;


        }
    }
}

