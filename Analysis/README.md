# Snappet Data Challenge for Data Scientist position - Bram Zandbelt

## Overview

This directory contains an RMarkdown document, `snappet_challenge_notebook.Rmd` that describes and performs a set of data processing, analysis, and visualization steps on a dataset from Snappet. The ultimate result of this analysis is a number of visualizations that provide an overview of a classroom’s activity on March 24th 2015 at 11:30 AM UTC, describing what pupils have worked and how they have worked. With these visualizations, I intended to provide (deep) insight, without being overwhelming.

## Getting started

### Requirements

* [R version 3.5.1 or higher](https://cran.r-project.org/src/base/R-3/)
* [RStudio Desktop](https://www.rstudio.com/products/rstudio/download/)
* The following R packages:
    * [tidyverse](https://tidyverse.tidyverse.org/)
    * [rprojroot](https://github.com/r-lib/rprojroot)
    * [knitr](https://yihui.name/knitr/)
    * [summarytools](https://github.com/dcomtois/summarytools)
    * [scatterpie](https://cran.r-project.org/web/packages/scatterpie/vignettes/scatterpie.html)
    * [cowplot]( 	https://github.com/wilkelab/cowplot)

These R packages can be installed from the command line in RStudio by running the following:

```
install.packages("tidyverse", dependencies = TRUE)
install.packages("rprojroot", dependencies = TRUE)
install.packages("knitr", dependencies = TRUE)
install.packages("summarytools", dependencies = TRUE)
install.packages("scatterpie", dependencies = TRUE)
install.packages("cowplot", dependencies = TRUE)
```
### Usage

The notebook should be opened in RStudio. Next, the notebook can be run interactively (Run -> Run All), or it can be "knitted" into a static HTML notebook. The latter has already been done, and the result can be found in `snappet_challenge_notebook.html`. The notebook contains explanatory text and code is commented.
