function createHeroesRegister(heroesData) {
    const heroes = [];
  
    for (const heroData of heroesData) {
      const [heroName, heroLevel, itemsString] = heroData.split(" / ");
      const items = itemsString ? itemsString.split(", ") : [];
  
      const hero = {
        name: heroName,
        level: Number(heroLevel),
        items: items
      };
  
      heroes.push(hero);
    }
  
    heroes.sort((a, b) => a.level - b.level);
  
    let output = "";
    for (const hero of heroes) {
      output += `Hero: ${hero.name}\n`;
      output += `level => ${hero.level}\n`;
      output += `items => ${hero.items.join(", ")}\n`;
    }
  
    return output.trim();
  }
  
  const input1 = [
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
  ];
  
  console.log(createHeroesRegister(input1));
  