﻿namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.SharedTypes;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.World.Water;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;								 

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class AshlarBasaltv1Recipe : RecipeFamily
    {
        public AshlarBasaltv1Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AshlarBasaltv1",  //noloc
                displayName: Localizer.DoStr("Ashlar Basalt"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasaltItem), 12, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(MortarItem), 3, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<AshlarBasaltItem>(1),
                    new CraftingElement<CrushedBasaltItem>(typeof(MasonrySkill), 1, typeof(MasonryLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f; // Defines how much experience is gained when crafted.
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(AshlarBasaltv1Recipe), start: 0.2f, skillType: typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Ashlar Basalt"), recipeType: typeof(AshlarBasaltv1Recipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MasonryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
