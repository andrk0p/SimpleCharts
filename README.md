# Simple Charts for Xamarin Forms

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
