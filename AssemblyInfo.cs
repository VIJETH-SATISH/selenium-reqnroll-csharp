using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

//[assembly: Parallelizable(ParallelScope.Fixtures)]
//[assembly: LevelOfParallelism(4)]

[assembly: Parallelizable(ParallelScope.None)]
[assembly: LevelOfParallelism(1)]

