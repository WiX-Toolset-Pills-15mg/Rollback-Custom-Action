// WiX Toolset Pills 15mg
// Copyright (C) 2019-2022 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace DustInTheWind.RollbackCustomAction.CustomActions.CrushModel
{
    internal class Crush
    {
        public void Execute(CrushParameters crushParameters)
        {
            string errorMessage = crushParameters.ErrorMessage;

            bool errorMessageExists = !string.IsNullOrEmpty(errorMessage);
            if (errorMessageExists)
                throw new Exception(errorMessage);
        }
    }
}