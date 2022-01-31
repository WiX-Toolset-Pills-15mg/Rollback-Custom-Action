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
using DustInTheWind.RollbackCustomAction.CustomActions.CrushModel;
using Microsoft.Deployment.WindowsInstaller;

namespace DustInTheWind.RollbackCustomAction.CustomActions
{
    // ================================================================================
    // Step 1 - C# Implementation
    // ================================================================================
    //
    // NEXT: CustomActions.wxs

    public static class CustomActions
    {
        /// <summary>
        /// This is a normal custom action implementation.
        /// </summary>
        [CustomAction]
        public static ActionResult DoSomething(Session session)
        {
            session.Log("----> Start DoSomething");
            try
            {
                return ActionResult.Success;
            }
            finally
            {
                session.Log("----> End DoSomething");
            }
        }

        /// <summary>
        /// The rollback custom action's implementation is no different than any other custom action.
        /// </summary>
        [CustomAction]
        public static ActionResult DoSomethingRollback(Session session)
        {
            session.Log("----> Start DoSomethingRollback");
            try
            {
                return ActionResult.Success;
            }
            finally
            {
                session.Log("----> End DoSomethingRollback");
            }
        }

        /// <summary>
        /// This custom action is used just for raising an error.
        /// </summary>
        [CustomAction]
        public static ActionResult Crush(Session session)
        {
            session.Log("----> Start Crush");
            try
            {
                CrushParameters parameters = new CrushParameters(session);

                Crush crush = new Crush();
                crush.Execute(parameters);

                session.Log("Actually, no error occurred.");
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log($"Error: {ex}");
                return ActionResult.Failure;
            }
            finally
            {
                session.Log("----> End Crush");
            }
        }
    }
}