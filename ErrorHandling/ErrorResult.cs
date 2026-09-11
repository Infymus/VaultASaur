/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

namespace VaultASaur3.ErrorHandling
{
    public class tErrorResult
    {
        public bool errorResult { get; set; } = false;
        public string errorMessage { get; set; } = string.Empty;
        public int AsInteger { get; set; }
        public string AsString { get; set; } = string.Empty;
        public bool AsBoolean { get; set; }
        public long AsLong { get; set; }
        public double AsDouble { get; set; }
        public DateTime AsDateTime { get; set; }
    }
}
