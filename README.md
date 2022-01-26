# Rollback Custom Action

## Description

Sometimes, when we install a product, the environment does not meet all the necessary criteria and some step from the installation process crushes. What happens with the changes made by the previous steps that completed successfully? How can the installer undo those changes?

## How to use

### a) Tutorial (article)

-  [doc/article/README.md](doc/article/README.md)
-  This document contains a step-by-step tutorial. You can find there explanations on solving the described problem.

### b) Code example

- [sources](sources)
- I provided the complete Visual Studio solution that solves the described problem. Check it out whenever you fill the need to test it by yourself, in your environment or if you have further ideas that you want to verify.

### c) Code notes

- A shorter version of the tutorial can be found directly in the source code. Open Visual Studio solution and search (Ctrl+Shift+F) for the `START` comment, then follow the `Step` comments.

- **Note:** The `NEXT` tags at the end of each comment indicates the file where to search for the next `Step`.

### d) Log file examples

- [doc/logs](doc/logs)
- Sometimes a quick look into the log files may be useful, but running the installer each time is cumbersome. I generated the log files for what I thought are the meaningful scenarios and I placed them into this directory. Have a look when needed.

## Suggestions

Any suggestion or opinion is appreciated. Please, feel free to add a [GitHub Issue](https://github.com/WiX-Toolset-Pills-15mg/Rollback-Custom-Action/issues/new?assignees=&labels=&template=feature_request.md&title=).

## Donations

> If you like my work and want to support me, you can buy me a coffee:
>
> [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y62EZ8H)

