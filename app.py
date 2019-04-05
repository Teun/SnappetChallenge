import pandas as pd
import numpy as np

import dash
import dash_core_components as dcc
import dash_html_components as html

import plotly.graph_objs as go

import itertools

tabs_style = {
    'height': '75px'
}

tab_style = {
    'borderBottom': '1px solid #d6d6d6',
    'fontFamily': 'Verdana',
    'fontSize': 18,
    'verticalAlign': 'middle'
}

tab_selected_style = {
    'borderTop': '1px solid #d6d6d6',
    'borderBottom': '1px solid #d6d6d6',
    'backgroundColor': '#119DFF',
    'color': 'white',
    'verticalAlign': 'middle',
    'fontFamily': 'Verdana',
    'fontSize': 18,
    'fontWeight': 'bold'
}

beschrijving_header_style = {
    'textAlign': 'left',
    'fontFamily': 'Verdana',
    'fontSize': 14,
    'fontWeight': 'bold',
    'marginTop': 10,
    'marginLeft': 10,
    'marginRight': 10
}

beschrijving_tekst_style = {
    'textAlign': 'left',
    'fontFamily': 'Verdana',
    'fontSize': 12,
    'marginTop': 25,
    'marginLeft': 10,
    'marginRight': 10
}

beschrijving_list_item = {
    'textAlign': 'left',
    'paddingTop': 0,
    'paddingLeft': 20,
    'paddingRight': 0,
    'paddingBottom': 0,
    'fontFamily': 'Verdana',
    'fontSize': 12,
    'textIndent': -17,
    'marginTop': 0,
    'marginLeft': 10,
    'marginRight': 10,
    'marginBottom': 0
}

# import data
snappet_01 = pd.read_csv('data_bewerkt.txt', sep = '\t', encoding = 'ISO-8859-1', low_memory = False)

# create lists with options for dropdown-menus
dag_options = [{'label': option, 'value': option} for option in list(snappet_01['Date'].unique())]
leerling_options = [{'label': option, 'value': option} for option in ['alle'] + [str(i) for i in list(sorted(snappet_01['UserId'].unique()))]]

app = dash.Dash(__name__)
server = app.server

app.layout = html.Div([
    dcc.Tabs(id = 'tabs', children = [
        
        # Activiteit
        
        dcc.Tab(label = 'Activiteit', style = tab_style, selected_style = tab_selected_style, children = [  
            html.Div([
                html.Div([
                    html.Div([html.Label('Selecteer dag:')], style = {'margin': '10px 10px 10px 50px',
                                                                      'fontFamily': 'Verdana',
                                                                      'fontSize': 12}
                    ),
                    html.Div([
                        dcc.Dropdown(id = 'dropdown_dag_activiteit',
                                     options = dag_options,
                                     value = '2015-03-24'
                                    )
                    ], style = {'margin': '0px 50px 25px 50px', 'fontFamily': 'Verdana', 'fontSize': 12}
                    )
                ], style = {'width': '20%', 'display': 'inline-block', 'verticalAlign': 'middle'}
                ),
                html.Div([
                    html.Img(src = app.get_asset_url('Snappet_logo.png'), style = {'height': '70',
                                                                                   'width': '180',
                                                                                   'margin': '10px 50px 10px 10px'})
                ], style = {'width': '80%', 'display': 'inline-block', 'verticalAlign': 'middle', 'textAlign': 'right'}
                ),
                html.Div([
                    html.Div([
                        html.Div('Beschrijving:', style = beschrijving_header_style),
                        html.P('Op deze pagina zie je waar de leerlingen op een betreffende dag aan hebben gewerkt.',
                               style = beschrijving_tekst_style),
                        html.P('In de bovenste grafiek zie je aan welke onderwerpen / domeinen is gewerkt, in de \
                                onderste grafiek zie je voor een betreffende leerling (of alle leerlingen gezamenlijk) \
                                aan welke leerdoelen is gewerkt.',
                               style = beschrijving_tekst_style),
                        html.P('Aandachtspunten:', style = beschrijving_tekst_style),
                        html.Ul([
                            html.Li('standaard is 2015-03-24 geselecteerd',
                                    style = beschrijving_list_item),
                            html.Li('in het menu kunnen andere dagen worden geselecteerd',
                                    style = beschrijving_list_item),
                            html.Li('de leerlingen staan op de y-as waarbij zowel individuele leerlingen als alle \
                                     leerlingen gezamenlijk kunnen worden geselecteerd',
                                    style = beschrijving_list_item),
                            html.Li('in iedere balk zijn de aandelen van de onderwerpen / domeinen zichtbaar',
                                    style = beschrijving_list_item),
                            html.Li('voor rekenen is het onderwerp vervangen door de onderliggende domeinen',
                                    style = beschrijving_list_item),
                            html.Li('de waarden zijn percentages (iedere balk telt op tot 100%)',
                                    style = beschrijving_list_item),
                            html.Li('door op een balk te klikken, zie je aan welke leerdoelen de betreffende leerling \
                                     heeft gewerkt',
                                    style = beschrijving_list_item)
                        ], style = {'list-style-position': 'inside', 'padding-left': 0})
                    ], style = {'width': '20%',
                                'display': 'inline-block'}
                    ),
                    html.Div([
                        html.Div([dcc.Graph(id = 'horizontal_barchart_activiteit')]),
                        html.Div([dcc.Graph(id = 'vertical_barchart_activiteit')])
                    ], style = {'width': '80%', 'display': 'inline-block', 'float': 'right'}
                    )
                ])
            ], style = {'width': '100%',
                        'height': '100%',
                        'display': 'inline-block',
                        'backgroundColor': 'rgb(250, 250, 250)',
                        'margin': '5px 0px 0px 0px',
                        'padding': '0px 0px 0px 0px'}
            )
            ]
        ),
        
        # Performance
        
        dcc.Tab(label = 'Performance', style = tab_style, selected_style = tab_selected_style, children = [  
            html.Div([
                html.Div([
                    html.Div([
                        html.Div([html.Label('Selecteer dag:')], style = {'margin': '10px 10px 10px 50px',
                                                                          'fontFamily': 'Verdana',
                                                                          'fontSize': 12}
                        ),
                        html.Div([
                            dcc.Dropdown(id = 'dropdown_dag_performance',
                                         options = dag_options,
                                         value = '2015-03-24')
                        ], style = {'margin': '0px 50px 25px 50px', 'fontFamily': 'Verdana', 'fontSize': 12}
                        )
                    ], style = {'width': '20%', 'display': 'inline-block', 'verticalAlign': 'middle'}
                    ),
                    html.Div([
                        html.Div([html.Label('Selecteer leerling:')], style = {'margin': '10px 10px 10px 50px',
                                                                               'fontFamily': 'Verdana',
                                                                               'fontSize': 12}
                        ),
                        html.Div([
                            dcc.Dropdown(id = 'dropdown_leerling_performance',
                                         options = leerling_options,
                                         value = 'alle')
                        ], style = {'margin': '0px 50px 25px 50px', 'fontFamily': 'Verdana', 'fontSize': 12}
                        )
                    ], style = {'width': '20%', 'display': 'inline-block', 'verticalAlign': 'middle'}
                    ),
                    html.Div([
                        html.Img(src = app.get_asset_url('Snappet_logo.png'), style = {'height': '70',
                                                                                       'width': '180',
                                                                                       'margin': '10px 50px 10px 10px'})
                    ], style = {'width': '60%', 'display': 'inline-block', 'verticalAlign': 'middle', 'textAlign': 'right'}
                ),
                ]
                ),
                html.Div([
                    html.Div([
                        html.Div('Beschrijving:', style = beschrijving_header_style),
                        html.P('Op deze pagina zie je de progressie die de leerlingen hebben geboekt op de verschillende \
                                onderwerpen / domeinen per uur van de dag.',
                               style = beschrijving_tekst_style),
                        html.P('In de bovenste grafiek zie je de geboekte progressie per onderwerp / domein voor ieder \
                                gewerkt uur van de dag. Een donkere kleur geeft aan dat er meer progressie is geboekt.',
                               style = beschrijving_tekst_style),
                        html.P('Door een combinatie van onderwerp / domein en uur van de dag te selecteren, verschijnt een \
                                grafiek die aangeeft hoe de progressie is op de onderliggende leerdoelen van het betreffende \
                                onderwerp / domein en uur.',
                               style = beschrijving_tekst_style),
                        html.P('Aandachtspunten:', style = beschrijving_tekst_style),
                        html.Ul([
                            html.Li('standaard is 2015-03-24 geselecteerd',
                                    style = beschrijving_list_item),
                            html.Li('in het menu kunnen andere dagen worden geselecteerd',
                                    style = beschrijving_list_item),                            
                            html.Li('in het menu kan een specifieke leerling worden geselecteerd maar ook kunnen alle \
                                     leerlingen gezamenlijk worden geselecteerd',
                                    style = beschrijving_list_item),
                            html.Li('per combinatie van onderwerp / domein en uur is de progressie gesommeerd',
                                    style = beschrijving_list_item)
                            ], style = {'list-style-position': 'inside', 'padding-left': 0})
                    ], style = {'width': '20%', 'display': 'inline-block'}
                    ),
                    html.Div([
                        html.Div([dcc.Graph(id = 'heatmap_performance')]),
                        html.Div([dcc.Graph(id = 'vertical_barchart_performance')])
                    ], style = {'width': '80%', 'display': 'inline-block', 'float': 'right'}
                    )
                ])
            ], style = {'width': '100%',
                        'height': '1800px',
                        'display': 'inline-block',
                        'backgroundColor': 'rgb(250, 250, 250)',
                        'margin': '5px 0px 0px 0px',
                        'padding': '0px 0px 0px 0px'}
            )
            ]
        )
    ])
])

##################
### activiteit ###
##################

@app.callback(
    dash.dependencies.Output('horizontal_barchart_activiteit', 'figure'),
    [dash.dependencies.Input('dropdown_dag_activiteit', 'value')])

def update_graph_activiteit(dag_activiteit):
    
    # per leerling
    
    snappet_01['Date'] = snappet_01['Date'].apply(lambda x: str(x))
    snappet_02 = snappet_01.loc[snappet_01['Date'] == dag_activiteit]
    
    snappet_02 = snappet_02.copy()
    
    snappet_03 = snappet_02.groupby(['Date', 'UserId', 'Group']) \
                           .agg({'Correct': 'count'}) \
                           .reset_index() \
                           .rename(columns = {'Correct': 'Group_count'})

    snappet_04 = snappet_02.groupby(['Date', 'UserId']) \
                           .agg({'Correct': 'count'}) \
                           .reset_index() \
                           .rename(columns = {'Correct': 'Total_count'})
    
    snappet_05 = snappet_03.merge(snappet_04, on = ['Date', 'UserId'], how = 'inner')
    snappet_05['Group_percentage'] = snappet_05['Group_count'] / snappet_05['Total_count']
    snappet_05['UserId'] = snappet_05['UserId'].astype(str)
    
    # hele klas
    
    snappet_06 = snappet_02.groupby(['Date', 'Group']) \
                           .agg({'Correct': 'count'}) \
                           .reset_index() \
                           .rename(columns = {'Correct': 'Group_count'})
    
    snappet_07 = snappet_02.groupby(['Date']) \
                           .agg({'Correct': 'count'}) \
                           .reset_index() \
                           .rename(columns = {'Correct': 'Total_count'})
    
    snappet_08 = snappet_06.merge(snappet_07, on = 'Date', how = 'inner')
    snappet_08['Group_percentage'] = snappet_08['Group_count'] / snappet_08['Total_count']
    snappet_08['UserId'] = 'alle'
    
    # samenvoegen
    
    snappet_09 = pd.concat([snappet_05, snappet_08], axis = 0)

    all_groups = list(snappet_01['Group'].unique())
    all_leerlingen = list(snappet_09['UserId'].unique())
    all_combinations = pd.DataFrame(list(itertools.product(all_leerlingen, all_groups)), columns = ['UserId', 'Group'])
    
    snappet_10 = all_combinations.merge(snappet_09, on = ['UserId', 'Group'], how = 'left')
    snappet_10.fillna(0, inplace = True)
        
    snappet_11 = snappet_10.pivot(index = 'UserId', columns = 'Group', values = 'Group_percentage')

    top_labels = list(snappet_11.columns)
    
    colors = ['rgba(255, 255, 0, 0.8)',
              'rgba(0, 128, 0, 0.8)',
              'rgba(255, 165, 0, 0.8)',
              'rgba(0, 128, 128, 0.8)',
              'rgba(255, 20, 147, 0.8)',
              'rgba(210, 105, 30, 0.8)']
    
    legends = list(snappet_11.columns)
    x_data = snappet_11.values.tolist()
    y_data = list(snappet_11.index)
    
    traces = []

    for i in range(0, len(x_data[0])):
        count = 0
        for xd, yd in zip(x_data, y_data):
            if count == 0:
                traces.append(go.Bar(x = [xd[i]],
                                     y = [yd],
                                     orientation = 'h',
                                     hoverinfo = 'none',
                                     name = legends[i],
                                     marker = dict(color = colors[i],
                                                   line = dict(color = 'rgb(248, 248, 249)',
                                                               width = 5)
                                                  )
                                    )
                             )
            else:
                traces.append(go.Bar(x = [xd[i]],
                                     y = [yd],
                                     orientation = 'h',
                                     hoverinfo = 'none',
                                     showlegend = False,
                                     marker = dict(color = colors[i],
                                                   line = dict(color = 'rgb(248, 248, 249)',
                                                               width = 5)
                                                  )
                                    )
                             )              
            count += 1
    
    layout = go.Layout(margin = {'l': 50, 'b': 50, 't': 100, 'r': 50},
                       title = 'Waar heeft de klas vandaag aan gewerkt?',
                       height = 800,
                       xaxis = {'showgrid': False,
                                'showline': False,
                                'showticklabels': True,
                                'zeroline': False,
                                'tickmode': 'array',
                                'tickvals': [0, 0.25, 0.5, 0.75, 1],
                                'ticktext': ['0%', '25%', '50%', '75%', '100%'],
                                'ticks': 'outside',
                                'side': 'top',
                                'domain': [0.1, 1.0]},
                       yaxis = {'type': 'category',
                                'showgrid': False,
                                'ticklen': 5,
                                'showline': False,
                                'showticklabels': True,
                                'zeroline': False,
                                'domain': [0.05, 0.95]},
                       barmode = 'stack',
                       legend = {'orientation': 'h',
                                 'yanchor': 'top',
                                 'xanchor': 'center',
                                 'x': 0.5,
                                 'y': 1.05,
                                 'font': {'size': 12,
                                          'color': '#000000'},
                                 'bgcolor': '#FFFFFF',
                                 'borderwidth': 0
                                }
                      )
    
    return {'data': traces, 'layout': layout}

@app.callback(
    dash.dependencies.Output('vertical_barchart_activiteit', 'figure'),
    [dash.dependencies.Input('horizontal_barchart_activiteit', 'clickData'),
     dash.dependencies.Input('dropdown_dag_activiteit', 'value'),])

def update_vertical_barchart_activiteit(clickData, dag_activiteit):

    snappet_01['Date'] = snappet_01['Date'].apply(lambda x: str(x))
    
    if clickData is None:
        leerling_activiteit = 'alle'
    else:
        leerling_activiteit = clickData['points'][0]['y']
    
    if leerling_activiteit == 'alle':
        snappet_02 = snappet_01.loc[snappet_01['Date'] == dag_activiteit]['LearningObjective'].value_counts(dropna = False)
        text = 'De leerlingen hebben op <b>{}</b> aan de volgende leerdoelen gewerkt:'.format(dag_activiteit)
    else:
        snappet_02 = snappet_01.loc[(snappet_01['Date'] == dag_activiteit) &
                                    (snappet_01['UserId'] == int(leerling_activiteit))]['LearningObjective'].value_counts(dropna = False)
            
        text = 'Leerling <b>{}</b> heeft op <b>{}</b> aan de volgende leerdoelen gewerkt:'.format(leerling_activiteit, dag_activiteit)
    
    snappet_03 = snappet_02.to_frame()
    snappet_04 = snappet_01[['LearningObjective', 'Color']].drop_duplicates().set_index('LearningObjective')
    snappet_05 = snappet_03.merge(snappet_04, left_index = True, right_index = True, how = 'left')

    return {'data': [go.Bar(x = list(snappet_05.index),
                            y = snappet_05['LearningObjective'].values.tolist(),
                            marker = {'color': snappet_05['Color'].values,
                                      'line': {'color': 'rgb(0, 0, 0)',
                                               'width': 2}
                                  },
                            opacity = 0.75)
                    ],
            'layout': go.Layout(margin = {'l': 200, 't': 50, 'r': 100, 'b': 500},
                                height = 1000,
                                xaxis = {'showline': True,
                                         'ticklen': 5,
                                         'tickangle': 90},
                                yaxis = {'title': 'aantal opdrachten',
                                         'showline': True},
                                bargap = 0.1,
                                annotations =  [{'x': 0,
                                                 'y': 1.05,
                                                 'xanchor': 'left',
                                                 'yanchor': 'bottom',
                                                 'xref': 'paper',
                                                 'yref': 'paper',
                                                 'font': {'family': 'Verdana',
                                                          'size': 12,
                                                          'color': '#000000'},
                                                 'showarrow': False,
                                                 'align': 'left',
                                                 'bgcolor': 'rgba(255, 255, 255, 0)',
                                                 'text': text}])
            }

###################
### performance ###
###################

@app.callback(
    dash.dependencies.Output('heatmap_performance', 'figure'),
    [dash.dependencies.Input('dropdown_dag_performance', 'value'),
     dash.dependencies.Input('dropdown_leerling_performance', 'value')])

def update_heatmap_performance(dag_performance, leerling_performance):
    
    # per leerling
    
    snappet_01['Date'] = snappet_01['Date'].apply(lambda x: str(x))
    snappet_02 = snappet_01.loc[snappet_01['Date'] == dag_performance]
    
    snappet_02 = snappet_02.copy()
    
    if leerling_performance == 'alle':
        snappet_03 = snappet_02.groupby(['Group', 'Hour_string']) \
                               .agg({'Progress': 'sum'}) \
                               .reset_index()
        
        table_text = 'Alle leerlingen gezamenlijk hebben op <b>{}</b> de volgende progressie geboekt:'.format(dag_performance)
    else:
        snappet_03 = snappet_02.loc[snappet_02['UserId'] == int(leerling_performance)] \
                               .groupby(['Group', 'Hour_string']) \
                               .agg({'Progress': 'sum'}) \
                               .reset_index()
        table_text = 'Leerling <b>{}</b> heeft op <b>{}</b> de volgende progressie geboekt:'.format(leerling_performance, dag_performance)
    
    all_uren = list(snappet_01['Hour_string'].unique())
    all_groups = list(snappet_01['Group'].unique())
    all_combinations = pd.DataFrame(list(itertools.product(all_uren, all_groups)), columns = ['Hour_string', 'Group'])
    
    snappet_04 = all_combinations.merge(snappet_03, on = ['Hour_string', 'Group'], how = 'left')

    snappet_05 = snappet_04.pivot(index = 'Group', columns = 'Hour_string', values = 'Progress')
    
    text_total = []

    for y_index, y_elem in enumerate(snappet_05.index):
        text_per_row = []
        for x_index, x_elem in enumerate(snappet_05.columns):
            text_per_element = ('Tijdstip: {}<br>'+
                                'Onderwerp / domein: {}<br>'+
                                'Progressie: {:.0f}').format(x_elem, y_elem, snappet_05.values.tolist()[y_index][x_index])
            text_per_row.append(text_per_element)
        text_total.append(text_per_row)
    
    return {'data': [go.Heatmap(z = snappet_05.values.tolist(),
                                zmin = snappet_05.min(skipna = True).min(skipna = True),
                                zmax = snappet_05.max(skipna = True).max(skipna = True),
                                x = snappet_05.columns,
                                y = snappet_05.index,
                                text = text_total,
                                hoverinfo = 'text',
                                reversescale = True,
                                colorscale = 'Greens')
            ],
            'layout': go.Layout(margin = {'l': 300, 'b': 100, 't': 75, 'r': 100},
                                title = 'Hoe is de progressie van de leerlingen?',
                                height = 500,
                                xaxis = {
                                    'type': 'category',
                                    'ticklen': 0,
                                    'tickangle': 0,
                                    'showline': False,
                                    'zeroline': False
                                },
                                yaxis = {
                                    'showline': False,
                                    'zeroline': False,
                                    'domain': [0.1, 0.9]
                                },
                                annotations =  [{'x': 0,
                                                 'y': 0.95,
                                                 'xanchor': 'left',
                                                 'yanchor': 'bottom',
                                                 'xref': 'paper',
                                                 'yref': 'paper',
                                                 'font': {'family': 'Verdana',
                                                          'size': 12,
                                                          'color': '#000000'},
                                                 'showarrow': False,
                                                 'align': 'left',
                                                 'bgcolor': 'rgba(255, 255, 255, 0)',
                                                 'text': table_text}]
                                )
            }

@app.callback(
    dash.dependencies.Output('vertical_barchart_performance', 'figure'),
    [dash.dependencies.Input('heatmap_performance', 'clickData'),
     dash.dependencies.Input('dropdown_dag_performance', 'value'),
     dash.dependencies.Input('dropdown_leerling_performance', 'value')])

def update_vertical_barchart_performance(clickData, dag_performance, leerling_performance):
    
    snappet_01['Date'] = snappet_01['Date'].apply(lambda x: str(x))
    
    if clickData is None:
        return None
    else:
        hour_string_input = clickData['points'][0]['x']
        group_input = clickData['points'][0]['y']
        
        if leerling_performance == 'alle':
            snappet_02 = snappet_01.loc[(snappet_01['Date'] == dag_performance) &
                                        (snappet_01['Group'] == group_input) &
                                        (snappet_01['Hour_string'] == hour_string_input)]
            snappet_02 = snappet_02.copy()
            
            snappet_03 = snappet_02.groupby('LearningObjective') \
                                   .agg({'Progress': 'sum'}) \
                                   .reset_index() \
                                   .set_index('LearningObjective')
            
            text = ('Alle leerlingen gezamenlijk hebben op <b>{}</b> om <b>{}</b> in het onderwerp / domein <b>{}</b> op <br>'+
                    'onderstaande leerdoelen de volgende progressie geboekt:').format(dag_performance,
                                                                                      hour_string_input,
                                                                                      group_input.lower())
        
        else:
            snappet_02 = snappet_01.loc[(snappet_01['Date'] == dag_performance) &
                                        (snappet_01['UserId'] == int(leerling_performance)) &
                                        (snappet_01['Group'] == group_input) &
                                        (snappet_01['Hour_string'] == hour_string_input)]
            snappet_02 = snappet_02.copy()
    
            snappet_03 = snappet_02.groupby('LearningObjective') \
                                   .agg({'Progress': 'sum'}) \
                                   .reset_index() \
                                   .set_index('LearningObjective')
    
            text = ('Leerling {} heeft op <b>{}</b> om <b>{}</b> in het onderwerp / domein <b>{}</b> op <br>'+
                    'onderstaande leerdoelen de volgende progressie geboekt:').format(leerling_performance,
                                                                                      dag_performance,
                                                                                      hour_string_input,
                                                                                      group_input.lower())

        return {'data': [go.Bar(x = list(snappet_03.index),
                            y = snappet_03['Progress'].values.tolist(),
                            marker = {'color': 'rgba(29, 114, 56, 0.8)',
                                      'line': {'color': 'rgb(0, 0, 0)',
                                               'width': 2}
                                  },
                            opacity = 0.75)
                        ],
                'layout': go.Layout(margin = {'l': 200, 't': 50, 'r': 100, 'b': 500},
                                height = 1000,
                                xaxis = {'showline': True,
                                         'ticklen': 5,
                                         'tickangle': 90,
                                         'domain': [0.1, 0.9]},
                                yaxis = {'title': 'progressie',
                                         'showline': True,
                                         'domain': [0.1, 0.9]},
                                bargap = 0.1,
                                annotations =  [{'x': 0.1,
                                                 'y': 0.975,
                                                 'xanchor': 'left',
                                                 'yanchor': 'bottom',
                                                 'xref': 'paper',
                                                 'yref': 'paper',
                                                 'font': {'family': 'Verdana',
                                                          'size': 12,
                                                          'color': '#000000'},
                                                 'showarrow': False,
                                                 'align': 'left',
                                                 'bgcolor': 'rgba(255, 255, 255, 0)',
                                                 'text': text}])
                }

app.css.append_css({
    'external_url': 'https://codepen.io/chriddyp/pen/bWLwgP.css'
})

if __name__ == '__main__':
    app.run_server()