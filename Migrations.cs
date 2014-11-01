using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Rimango.Gallery
{
    public class Migrations : DataMigrationImpl
    {

        public int Create()
        {

            this.ContentDefinitionManager.AlterTypeDefinition("Gallery",
                ct => ct.WithPart("CommonPart")
                          .WithPart("AutoroutePart")
                          .WithPart("MenuPart")
                          .WithPart("TitlePart")
                          .WithPart(
                              "ContainerPart",
                              part => part.WithSetting("ContainerTypePartSettings.RestrictedItemContentTypes", "GalleryEntry")
                                            .WithSetting("ContainerTypePartSettings.RestrictItemContentTypes", "True"))
                          .Creatable(true)
                          .Draftable(true)
                                            );


            this.ContentDefinitionManager.AlterPartDefinition("GalleryEntryPart",
                b => b.WithField("Pictures",
                    field => field.OfType("MediaLibraryPickerField")
                            .WithSetting("MediaLibraryPickerFieldSettings.Required", "True")
                            .WithSetting("MediaLibraryPickerFieldSettings.Multiple", "True"))
                            .WithDescription("Pictures")
                );

            this.ContentDefinitionManager.AlterTypeDefinition("GalleryEntry",
                ct => ct.WithPart("CommonPart")
                        .WithPart("AutoroutePart",
                        p => p.WithSetting("AutorouteSettings.PatternDefinitions",
                        @"[{Name:'ParentTitle', Pattern:'{Content.ParentPath}{Content.Slug}', Description:'Parent'}]")
                                .WithSetting("AutorouteSettings.AllowCustomPattern", "false")
                                .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "true"))
                        .WithPart("GalleryEntryPart")
                          .WithPart(
                              "ContainablePart",
                              part => part.WithSetting("ContainableTypePartSettings.ShowContainerPicker", "true"))
                          .Creatable(true)
                          .Draftable(true)
                              );
            return 1;
        }

        public int UpdateFrom1()
        {
            this.ContentDefinitionManager.AlterTypeDefinition("GalleryEntry",
                ct => ct.WithPart("TitlePart"));

            return 2;
        }

        public int UpdateFrom2()
        {
            // < ImageFieldSettings.AlternateText="False" ImageFieldSettings.ResizeAction="UserCrop" ImageFieldSettings.UserCropOption="OnlyKeepRatio" />

            this.ContentDefinitionManager.AlterPartDefinition(
                "GalleryEntryPart",
                part =>
                part.WithField(
                    "CoverPicture",
                    f => f
                        .OfType("ImageField")
                        .WithSetting("ImageFieldSettings.MaxHeight", "210")
                        .WithSetting("ImageFieldSettings.MaxWidth", "400")
                        .WithSetting("ImageFieldSettings.Required", "true")
                        .WithSetting("ImageFieldSettings.MediaFolder", "_Gallery/CoverPictures/{content-item-id}")
                        .WithSetting("ImageFieldSettings.ResizeAction", "UserCrop")
                        .WithSetting("ImageFieldSettings.UserCropOption", "OnlyKeepRatio")
                        ));

            return 3;
        }
    }
}