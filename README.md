# Simple Charts for Xamarin Forms

[![NuGet version](https://badge.fury.io/nu/SimpleCharts.svg)](https://badge.fury.io/nu/SimpleCharts)

| Property | Type | Description |
|----------------|:---------:|----------------:|
| Value | double | By default, it is zero. |
| IsAnimation | bool | Specifies whether columns will change their height with animation. |
| IsMinAllowed | bool | If you have a critical value, this field includes the ability to add multiple colors and the minimum allowed value. |
| MinColor | Color | Columns that are lower than the minimum allowed value will be displayed in this color. |
| MaxColor | Color | Columns that are higher than the minimum allowed value will be displayed in this color. |
| MinAllowedValue | double | Minimum allowed value. |

## Support platforms

- [x] Android
- [x] iOS
- [x] UWP

## Sample

 ```
 <templates:Charts BindableLayout.ItemsSource="{Binding Charts}" HeightRequest="{Binding MaxHeight}"
                   Spacing="10">
                <BindableLayout.ItemTemplate>
                    <DataTemplate>
                        <templates:Chart Value="{Binding Value}"
                                         MinColor="{Binding MinColor}"
                                         MaxColor="{Binding MaxColor}"
                                         MinAllowedValue="250">
                            <Grid Grid.Row="1" BackgroundColor="White">
                                <Label Text="{Binding Value}" HorizontalOptions="CenterAndExpand" TextColor="Black"/>
                            </Grid>
                        </templates:Chart>
                    </DataTemplate>
                </BindableLayout.ItemTemplate>
 </templates:Charts>
```

![Xamarin forms charts](https://github.com/somewv/SimpleCharts/blob/main/SimpleChart.PNG)
