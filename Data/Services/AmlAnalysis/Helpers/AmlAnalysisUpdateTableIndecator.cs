﻿namespace Data.Services.AmlAnalysis
{
    public class AmlAnalysisUpdateTableIndecator
    {
        private bool ind = false;
        private readonly object _locker = new();
        public bool PerformInd
        {
            get
            {
                lock (_locker)
                {
                    return ind;
                }
            }
            set
            {
                lock (_locker)
                {
                    ind = value;
                }
            }
        }
    }
}
