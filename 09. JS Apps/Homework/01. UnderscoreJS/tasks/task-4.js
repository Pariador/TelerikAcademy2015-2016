/*
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **groups** the animals by `species`
    *   the groups are sorted by `species` descending
*   **sorts** them ascending by `legsCount`
	*	if two animals have the same number of legs sort them by name
*   **prints** them to the console in the format:

```
    ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
    GROUP_1_NAME:
    ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
    NAME has LEGS_COUNT legs //for the first animal in group 1
    NAME has LEGS_COUNT legs //for the second animal in group 1
    ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
    GROUP_2_NAME:
    ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
    NAME has LEGS_COUNT legs //for the first animal in the group 2
    NAME has LEGS_COUNT legs //for the second animal in the group 2
    NAME has LEGS_COUNT legs //for the third animal in the group 2
    NAME has LEGS_COUNT legs //for the fourth animal in the group 2
```
*   **Use underscore.js for all operations**
*/

function solve() {
    return function(animals) {
        function printGroups(groups) {
            var i,
                len,
                dashes,
                groupName,
                animalString,
                result = '',
                animals,
                group;
            for (group in groups) {
                dashes = Array(group.length + 2).join('-');
                console.log(dashes);

                groupName = group + ':';
                console.log(groupName);
                console.log(dashes);

                animals = groups[group];
                for (i = 0, len = animals.length; i < len; i+=1) {
                    animalString = animals[i].name + ' has ' + animals[i].legsCount + ' legs';
                    console.log(animalString);
                }
            }
        }

        var i, len, species;

        var sortedAnimals = _.sortBy(animals, 'species');
            sortedAnimals.reverse();



        var result = _.chain(sortedAnimals)
                        .groupBy('species')
                        .each(function(animals, group, groups) {
                            groups[group] = _.chain(animals)
                                            .sortBy('name')
                                            .sortBy('legsCount')
                                            .value();
                        })
                        .value();

        printGroups(result);
    }
}
module.exports = solve;