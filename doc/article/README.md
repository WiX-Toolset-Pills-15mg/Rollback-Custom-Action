# Rollback Custom Action

## Description

Sometimes, when we install a product, the environment does not meet all the necessary criteria and some step from the installation process crushes. What happens with the changes made by the previous steps that completed successfully? How can the installer undo those changes?

Fore each custom action that does a change in the system we must provide an additional custom action that reverts that change. We call this a rollback custom action.

## Step 1 - C# Implementation

Create the custom action and its corresponding rollback custom action in C#:

```csharp
[CustomAction]
public static ActionResult DoSomething(Session session)
{
    // do some changes here.

    return ActionResult.Success;
}

[CustomAction]
public static ActionResult DoSomethingRollback(Session session)
{
    // revert the changes here.

    return ActionResult.Success;
}
```

Actually, in C# a custom action that will be later used for rollback has nothing different than a normal custom action. It just needs to be static and have the `CustomAction` attribute as any other custom action.

## Step 2 - WiX declaration

Now let's declare the two custom actions in WiX:

```xml
<CustomAction
    Id="DoSomething"
    BinaryKey="CustomActionsBinary"
    DllEntry="DoSomething"
    Execute="deferred"
    Return="check" />

<CustomAction
    Id="DoSomethingRollback"
    BinaryKey="CustomActionsBinary"
    DllEntry="DoSomethingRollback"
    Execute="rollback"
    Return="check" />
```

At this level, we need to take care of two things:

- The normal custom action must have `Execute="deferred"`.
  - The rollback mechanism does not work with immediate custom actions.
- The rollback custom action must have `Execute="rollback"`.

## Step 3 - Installation sequence

Now we need to include the two custom actions into the installation sequence:

```xml
<InstallExecuteSequence>
    <Custom Action="DoSomethingRollback" Before="DoSomething">InstallScenario</Custom>
    <Custom Action="DoSomething" After="InstallFiles">InstallScenario</Custom>
    ...
</InstallExecuteSequence>
```

The important aspects here are:

- **Rollback before Normal** - The rollback must be sequenced before the normal custom action (see the `Before="DoSomething"` attribute).

  - Each rollback custom action, as it is encountered in the execution sequence, is added into a list of actions without being executed. In case of an error, the entire list of rollback actions is executed.
  - By adding the rollback custom action before the normal custom action we ensure that it will be added in the rollback list and, later, run ether if its associated normal custom action or any subsequent custom action crushes.

- **Same execution condition** -  Both rollback and its associated custom action must have the same execution condition.

  Note: `InstallScenario` property used as execution condition in this example is a custom property created in this demo application in the `InstallationScenarios.wxs` file.

- **Normal before `InstallFinalize`** - The normal custom action must be sequenced somewhere before `InstallFinalize`.

  - This doesn't mean it must be immediately before `InstallFinalize`, but it should not be after it otherwise the rollback will not be performed.

