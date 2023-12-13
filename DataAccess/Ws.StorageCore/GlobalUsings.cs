global using System.Collections;
global using System.Collections.Generic;
global using System.ComponentModel;
global using System.Diagnostics;
global using System.IO;
global using System.Linq;
global using System.Runtime.Serialization;
global using System.Text;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Xml;
global using System.Xml.Linq;
global using System.Xml.Serialization;
global using System.Xml.Xsl;
global using FluentValidation;
global using FluentValidation.Results;
global using MDSoft.NetUtils;
global using Microsoft.Data.SqlClient;
global using NHibernate;
global using NHibernate.Criterion;
global using Ws.StorageCore.Common;
global using Ws.StorageCore.Helpers;
global using Ws.StorageCore.Models;
global using Ws.StorageCore.Utils;
global using Ws.StorageCore.Views.ViewDiagModels.TableSize;
global using Ws.StorageCore.Entities.SchemaDiag.Logs;
global using Ws.StorageCore.Entities.SchemaDiag.LogsWebs;
global using Ws.StorageCore.Entities.SchemaRef.ProductionSites;
global using Ws.StorageCore.Entities.SchemaRef.WorkShops;
global using Ws.StorageCore.Entities.SchemaRef1c.Boxes;
global using Ws.StorageCore.Entities.SchemaRef1c.Brands;
global using Ws.StorageCore.Entities.SchemaRef1c.Bundles;
global using Ws.StorageCore.Entities.SchemaRef1c.Clips;
global using Ws.StorageCore.Entities.SchemaRef1c.Plus;
global using Ws.StorageCore.Entities.SchemaScale.Access;
global using Ws.StorageCore.Entities.SchemaScale.Apps;
global using Ws.StorageCore.Entities.SchemaScale.BarCodes;
global using Ws.StorageCore.Entities.SchemaScale.PlusFks;
global using Ws.StorageCore.Entities.SchemaScale.PlusLabels;
global using Ws.StorageCore.Entities.SchemaScale.PlusNestingFks;
global using Ws.StorageCore.Entities.SchemaScale.PlusScales;
global using Ws.StorageCore.Entities.SchemaScale.PlusStorageMethods;
global using Ws.StorageCore.Entities.SchemaScale.PlusStorageMethodsFks;
global using Ws.StorageCore.Entities.SchemaScale.PlusTemplatesFks;
global using Ws.StorageCore.Entities.SchemaScale.PlusWeightings;
global using Ws.StorageCore.Entities.SchemaScale.Scales;
global using Ws.StorageCore.Entities.SchemaScale.Templates;
global using Ws.StorageCore.Entities.SchemaScale.TemplatesResources;
global using Ws.StorageCore.Entities.SchemaScale.Versions;