# Snappet Challenge Implementation
## RJA Boerma

Before running the solution please make sure to edit the `Web.Config` in the `SnappetChallenge` project. Set the setting `DefaultWorkJsonpath` to the path to the supplied work.json.
```xml
<applicationSettings>
    <SnappetChallenge.DAL.SnappetDal>
      <setting name="DefaultWorkJsonpath" serializeAs="String">
        <value>H:\git\Snappet\Data\work.json</value>
      </setting>
    </SnappetChallenge.DAL.SnappetDal>
  </applicationSettings>
```
Once set, the web page should simply pop-up when running the `SnappetChallenge` project

_Sidenote_: With the absence of a formal description of the data file I have made the _possibly_ incorrect assumption the values of `Correct` [0,1,3] have meaning in the ballpark of [incorrect, correct, superb]. Allowing me to count both 1 and 3 as correct.