VAR characterName = "Юрий(база)"
VAR characterExpression = 0
VAR Location = 0

~characterName="Рассказчик"
~characterExpression = 0
~Location = 0
 Просыпаться было тяжело. Все же не смотря на то, что хотел лечь раньше, заснуть удалось только глубокой ночью, когда луна занялась на небосводе. Мысли об новом для него мире занимали все мысли. Для чего же он все-таки здесь оказался, и как теперь вернуться домой. И только когда усталость дня взяла свое, все же наконец заснул.

~characterName="Рассказчик"
~characterExpression = 0
Но сейчас остается только сожалеть, что не лег рано. Было ощущение словно по телу пробежала целое стадо бизонов.

~characterName="Юрий"
~characterExpression = 0
– Черт, сколько я вообще поспал? - потирая слипшиеся глаза, сам у себя спросил тот.

~characterName="Рассказчик"
~characterExpression = 0
Оглянувшись на окно, тот увидел, что солнце уже вступило в свои права. Распахнув наконец глаза, Юрий резко обернулся в сторону часов, и обнаружил что времени сейчас без двадцати девять и до самого урока осталось всего ничего.

~characterName="Рассказчик"
~characterExpression = 0
Быстро вскочив с постели, попутно чуть не падая с неё, побежал в сторону своих вещей, быстро их натягивая на свое тело, после чего побежал в сторону ванной комнаты, чтобы хоть плеснуть себе в лицо воды, чтобы окончательно проснуться, и расчесать свои теперь уже длинные волосы.

~characterName="Рассказчик"
~characterExpression = 0
Быстро все это сделав, вернулся обратно в комнату, наспех одел ботинки и, прихватив заранее собранную сумку, побежал в сторону кабинета, все-таки повезло, что память у него достаточно хорошая и тот примерно помнит расположение кабинета по карте.

~characterName="Юрий"
~Location = 1
~characterExpression = 1
-	О, великая Бэндзайтэн, пожалуйста, только бы опять ничего не появилось по пути в кабинет, - едва не взмолился я богине удачи.

~characterName="Рассказчик"
~characterExpression = 0
Та, похоже, похоже все же сжалилась над ним, и тот добрался до кабинета без каких бы то не было приключений. Лишь опоздал всего на пару минут.

~characterName="Рассказчик"
~characterExpression = 0
~Location = 2
Но для учителя эти пару минут были словно концом света:

~characterName="Профессор Леший"
~characterExpression = 0
– Ученик Юрий, почему вы опоздали на мой урок? А если бы вы пропустили время сбора необходимых для вас даров природы?

~characterName="Профессор Леший"
~characterExpression = 1
Ругался на него старый учитель.

~characterName="Юрий"
~characterExpression = 2
Я с удивление опознал в нём Лешего. В голове тут же всплыло описание сего волшебного жителя.

~characterName="Рассказчик"
~characterExpression = 0
«Леший - это дух леса, который является людям в образе бородатого старика в странной одежде. Легко превращается в животное, птицу, гриб или дерево. Леший следит за порядком в лесных угодьях - заботится о зверях и растениях. Он любит подшучивать над охотниками и грибниками: шумит, подражает птичьим голосам, сбивает с дороги. Если человек наносит вред природе, лесовик может прогневаться и погубить его.»

~characterName="Юрий"
Пока я вспоминал все это, меня снова окликнули, теперь еще и прожигая недобрым взглядом.

~characterName="Юрий"
~characterExpression = 3
– Простите, учитель, я проспал, и из-за этого опоздал на урок, - постарался я смягчить того, а сам едва не умирал в мыслях от стыда:

~characterName="Юрий"
~characterExpression = 2
– «О, Ками, меня так не отчитывали со времен третьего класса младшей школы».

~characterName="Профессор Леший"
~characterExpression = 0
– Я слышал то, что вы вчера упали в обморок посреди коридора, но это не повод опаздывать на уроки, а уж тем более просыпать их.

~characterName="Профессор Леший"
~characterExpression = 1
Прищурив глаза, будто о чем то задумавшись, сообщил тот.

~characterName="Профессор Леший" 
~characterExpression = 0
– Ответьте мне на вопрос. Чем отличается пупавка от обычной ромашки?

~characterName="Профессор Леший"
~characterExpression = 1
Недобро сверкнув глазами, спросил Леший.

~characterName="Рассказчик"
~characterExpression = 0
Как только был произнесен вопрос, время будто остановилось. Следом за этим появилось уже знакомое окно системы.

~characterName="Система"
~characterExpression = 0
«Дорогой пользователь, выберите правильный вариант ответ. Наградой за него будет ответ на вопрос учителя.» 
    ->NotTrue

=== NotTrue ===
~characterName="Система"
~characterExpression = 0
«Какой из видов обхода графа существует?»
+[Прямой поиск]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->False

+[Поиск в глубину]
->True

+[Обратный поиск]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->False

=== False ===
~characterName="Система"
~characterExpression = 0
«Какие виды обхода дерева существуют?»
+[Обратный, ассиметричный, прямой]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->NotTrue

+[Прямой, симметричный, обратный]
->True

+[Прямой, обратный]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->NotTrue
+[Симметричный, прямой, асимметричный]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->NotTrue


=== True ===
~characterName="Система"
~characterExpression = 0
«Поздравляем, задание выполнено! Вы получаете свою награду: ответ преподавателю. Желаете ли вы им воспользоваться?»

~characterName="Юрий"
~characterExpression = 2
– «Да», - мысленно ответил я.

~characterName="Юрий"
~characterExpression = 3
– Пупавка отличается более крупными соцветиями и многообразием окраски лепестков, которые могут быть не только белыми, но и кремовыми или жёлтыми. Они хорошо растут на солнечных участках и устойчивы к засухе, - уже читая вслух из окошка системы, посмотрел на учителя, ожидая вердикт за свой ответ.

~characterName="Профессор Леший"
~characterExpression = 0
– Верно.

~characterName="Профессор Леший"
~characterExpression = 1
Несколько сварливо подтвердил тот.

~characterName="Профессор Леший"
~characterExpression = 0
- Можете сесть на место, но больше что б не опаздывали.

~characterName="Профессор Леший"
~characterExpression = 1
Вернувшись к своему столу, продолжил ворчать тот.

~characterName="Юрий"
~characterExpression = 3
– Да, профессор, - кивнул я, а после направился в сторону свободного места. И какого было моё удивление, когда я там же и вчерашнюю девушку.

~characterName="Мира"
~characterExpression = 0
– Привет, Юрий. 

~characterName="Мира"
~characterExpression = 4
Тихо поздоровалась та, при этом радостно улыбаясь.

~characterName="Юрий"
~characterExpression = 3
– Привет, Мира, - также шёпотом поздоровался я, присаживаясь на соседнее с девушкой место.

~characterName="Профессор Леший"
~characterExpression = 1
– Юрий, то что вы правильно ответили, не дает вам права срывать мой урок.

~characterName="Профессор Леший"
~characterExpression = 1
Хмуро глядя на меня, проворчал на весь класс Леший.

~characterName="Юрий"
~characterExpression = 3
– Да, учитель, - ответил ответил я, а потом тише сообщил Мире. - На перемене поговорим.

~characterName="Мира"
~characterExpression = 0
– Угу.

~characterName="Мира"
~characterExpression = 4
Согласилась та.

Мелодия окончания урока.

~characterName="Профессор Леший"
~characterExpression = 0
– Так на следующий урок подготовить доклад о полезных свойствах малины и чем можно ее заменить в снадобьях. Можете быть свободны.

~characterName="Профессор Леший"
~characterExpression = 1
Записывая домашнее задание на доске, сообщил тот.

~characterName="Юрий"
Не долго думая, я помог встать Мире, а после быстро вылетел из класса, при этом держа ту за руку.

~Location = 1
~characterName="Мира"
~characterExpression = 2
– Как тебе первый урок с Профессором Лешим? - задала та вопрос, когда их шаг замедлился.


+[Очень странный преподаватель. Чувствую у нас с ним будет холодная война.]
        ->answer


+[Он очень строгий преподаватель, но свой предмет знает и умеет преподавать. Думаю, он сумеет всему нас научить.]
~characterName="Система"
~characterExpression = 0
    Ваша симпатия с Мирой поднялась на 20 единиц.
        ->answer


=== answer ===
~characterName="Мира"
~characterExpression = 3
– Интересно. Ну а так он еще и дополнительные ведет, чтобы разъяснить, что нам не понятно, - идя чуть впереди меня, улыбнулась та.

~characterName="Юрий"
~characterExpression = 3
– Ну, если вдруг что-то будет не понятно, можно будет обратиться, - покивал головой я.

~characterName="Мира"
~characterExpression = 2
– Кстати, мы пришли, - указав рукой вперед, сказала Мира.


~characterName="Юрий"
~characterExpression = 2
– У нас ведь зелья?

~characterName="Мира"
~characterExpression = 2
– Да, с профессором Ягой. Старшие говорили, что только на первом уроке мы не работаем с живыми организмами для зелий, а после хоть стой, хоть падай, но будешь препарировать все живое на ингредиенты, - опечалено поведала та.


+[Ну и жуть, не хотелось бы это делать.]
    ->answer2

+[Ужас какой. Но если хочешь, этим могу заняться я, чтобы ты не видела всего этого.]
~characterName="Система"
~characterExpression = 0
    Ваша симпатия с Мирой поднялась на 20 единиц.
->answer2

=== answer2 ===
~characterName="Мира"
~characterExpression = 1
– Да, - печально вздохнула та, а после быстро взяла себя в руки.

~characterName="Мира"
~characterExpression = 2
– Ну что, заходим? - набравшись смелости, спросила та, при этом отворив дверь.

~characterName="Рассказчик"
~characterExpression = 0
~Location = 3
Нам предстало большое помещение, чем-то напоминающее подвальное помещение, только наличие разной атрибутики для зелий, да парты с доской указывали, что это все же класс.

~characterName="Юрий"
~characterExpression = 1
– Воу, - удивился я, после чего, за нашими с Мирой спинами раздался мелодичный смешок.
~characterName="Мира"
~characterExpression = 1
- Ого.

~characterName="Мира"
~characterExpression = 4
Также где-то в стороне обронила Мира.

~characterName="Ольга"
~characterExpression = 0
– Кабинет и правда впечатляет, не правда ли?

~characterName="Рассказчик"
~characterExpression = 0
Обладательницей голоса оказалась низкая девушка с розовыми волосами и карими глазами. На шее же висел крестик.

~characterName="Юрий"
~characterExpression = 3
– А ты..? - хотел спросить я, но меня опередили.

~characterName="Ольга"
~characterExpression = 1
– Меня зовут Ольга. Мы с вашим классом совмещаемся на зельях, заклинаниях и еще на паре предметов.

~characterName="Ольга"
~characterExpression = 4
Представилась та.

~characterName="Мира"
~characterExpression = 2
– Ты же внучка профессора Яги?

~characterName="Мира"
~characterExpression = 4
Спросила Мира, взяв ту за руки и проникновенно заглядывая в глаза.

~characterName="Ольга"
~characterExpression = 0
– Да.

~characterName="Ольга"
~characterExpression = 4
Нежно улыбнулась та, также смотря прямо в глаза собеседника.

~characterName="Мира"
~characterExpression = 2
– Но ведь вы не сильно похожи, по крайней мере характером точно.

~characterName="Мира"
~characterExpression = 4
Удивлялась та.

~characterName="Юрий"
~characterExpression = 1
Я же со стороны наблюдал за их диалогом, видя, что они могу стать хорошими подругами.

~characterName="Ольга"
~characterExpression = 2
– На самом деле, я может и хорошо разбираюсь в зельях, но предпочитаю колдовать, чем расфасовывать по колбам любовь и закупоривать смерть, - все также улыбаясь, промолвила та. 

~characterName="Ольга"
~characterExpression = 3
– Кстати, на зельях работают в группе по три человека. И если вы не против, можно я присоединюсь?

~characterName="Ольга"
~characterExpression = 4
Спросила та, чуть покраснев.

~characterName="Мира"
~characterExpression = 1
– Я не против.

~characterName="Мира"
~characterExpression = 4
Чуть подпрыгнув, оповестила Мира.


+[Я тоже не против, вместе веселей.]
->answer3

+[Я тоже не против, вместе мы точно сможем сделать идеальное зелье.]
~characterName="Система"
~characterExpression = 0
Ваша симпатия с Ольгой поднялась на 20 единиц.
->answer3

=== answer3 ===
~characterName="Ольга"
~characterExpression = 0
– Хорошо. Остальные идут, давайте займем места.

~characterName="Ольга"
~characterExpression = 4
Кивнула та и после сообщила.

~characterName="Мира"
~characterExpression = 2
– Хорошо.

~characterName="Мира"
~characterExpression = 4
Сказала Мира, и потянула нас с Ольгой в сторону средних рядов.

~characterName="Рассказчик"
~characterExpression = 0
Постепенно класс заполнился остальными учениками, а спустя пару мгновений из неожиданно появившегося дамы вышла и сама преподавательница.

~characterName="Рассказчик"
Баба Яга оказалась не такой старой как ее описывают в книгах. Да, волосы ее белы да длиной почти до пола, но не видно ни морщин, ни старческих пятен. Хотя возраст выдают глаза, все же не бывает такой бездны у молодой девушки.

~characterName="Профессор Яга"
~characterExpression = 0
– Итак класс, тема сегодняшнего урока травяные настои против болезней.

~characterName="Профессор Яга"
~characterExpression = 1
Начала та урок.

~characterName="Юрий"
Мы с девочками внимательно слушали теоретическую часть урока, иногда обсуждая то, что говорит учитель.

~characterName="Рассказчик"
~characterExpression = 0
Спустя двадцать минут, когда профессор Яга закончила лекционную часть, начала по очереди задавать вопросы по теме урока. 

~characterName="Профессор Яга"
~characterExpression = 0
– Юрий, какую траву можно использовать от кашля и почему?

~characterName="Профессор Яга"
~characterExpression = 1
Спросила та.

~characterName="Юрий"
~characterExpression = 0
–  «Черт, я же в этот момент отвлекся на вопрос Миры и не услышал название самой травы», - в панике подумал я.

~characterName="Ольга"
~characterExpression = 1
– Псс, Юрий, багульник.

~characterName="Ольга"
~characterExpression = 4
Тихо шепнула Ольга, и в голове сразу щелкнуло от осознания.

~characterName="Юрий"
~characterExpression = 2
– Профессор Яга, средством от кашля является багульник, - постарался сразу ответить я, чтобы не сильно была заметна заминка, а после продолжил:

~characterName="Юрий"
~characterExpression = 2
– Проблемы с отхождением слизи, ее застой в трахеях и бронхах, являются причиной изматывающих приступов кашля, справиться с которыми поможет трава багульника. Обладая муколитическим и антисептическим эффектом, багульник от кашля создает условия для разжижения мокрот и их отхода, устраняя первопричину кашля.

~characterName="Профессор Яга"
~characterExpression = 0
– Все верно, можешь сесть.

~characterName="Профессор Яга"
~characterExpression = 1
Кивнула та, а после спросила еще двух человек, после чего сказала всем взять нужные ингредиенты и сварить те средства, про которые мы ей отвечали.

~characterName="Рассказчик"
~characterExpression = 0
Сама варка зелья заняла не сильно много времени. Мы с девочками справились за оставшиеся полчаса до конца урока, после чего сдали зелье на проверку и вышли из класса.

~characterName="Ольга"
~characterExpression = 1
– Ну что же, было приятно с вами познакомиться, но мне нужно на нумерологию, так что встретимся уже на заклинаниях. Увидимся.

~characterName="Ольга"
~characterExpression = 4
Мягко улыбнувшись, попрощалась с нами Ольга. 

~characterName="Юрий"
~Location = 1
Мы так же попрощались с ней после чего пошли уже на свой урок. 

~characterName="Рассказчик"
~characterExpression = 0
На физической подготовке не было ничего интересного, за исключение того, что вел ее Алеша Попович. Но и этот урок быстро прошел, после чего направилась уже на последний наш урок, на котором мы снова встретим Ольгу.

~characterName="Рассказчик"
~characterExpression = 0
~Location = 4
Уже заходя в класс, мы с Мирой видим, как она легонько машет нам, тем самым подзывая к себе.

~characterName="Ольга"
~characterExpression = 2
– Привет, - поприветствовала она нас. - Какой у вас был предмет?

~characterName="Юрий"
~characterExpression = 2
– Физическая подготовка, - ответил я, так как Мира все еще была красная и уставшая от бега.

~characterName="Ольга"
~characterExpression = 2
– Сочувствую, профессор Попович очень сильно гоняет, сама тоже вчера это испытала, - протягивая бутылочку с водой Мире, сказала та.

~characterName="Ольга"
~characterExpression = 3
– Лучше садитесь, сейчас урок начнётся, и сможете передохнуть.

~characterName="Ольга"
~characterExpression = 4
Подвинувшись на скамье предложила та, вновь нежно улыбнувшись.

~characterName="Юрий"
~characterExpression = 0
– Спасибо, - пропустив Миру вперед, ответил я.

~characterName="Юрий"
После этого в класс зашла уже Василиса Премудрая. Я предполагал, что именно она будет преподавать заклинания, поэтому не сильно удивился.

~characterName="Рассказчик"
~characterExpression = 0
Лекция текла легка, профессор все предельно ясно объясняла, отчего невозможно было не понять, о чем вообще шла речь.

~characterName="Рассказчик"
~characterExpression = 0
После всей вводной части мы начали заниматься практикой, произнося магические формулы и взмахивая руками, придавая заклинанию больше силы, и все выходило неплохо, пока время вновь не остановилось.

~characterName="Система"
~characterExpression = 0
«Уважаемый пользователь, обнаружена ошибка, сопровождаемая коррозией»

~characterName="Юрий"
~characterExpression = 1
–  «О, Ками, ну почему сейчас», - взмолился я.

~characterName="Система"
~characterExpression = 0
«Для ее исправления необходимо выбрать правильный варииант ответа»

->IsntTrue

=== IsntTrue ===
~characterName="Система"
~characterExpression = 0
«Как обозначается цветовое пространство для экранов?»

+[HSB]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->IsFalse

+[HSL]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->IsFalse

+[CMYK]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->IsFalse

+[RGB]
->IsTrue

=== IsFalse ===
~characterName="Система"
~characterExpression = 0
«Как обозначается цветовое пространство для печати?»

+[RGB]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->IsntTrue

+[CMYK]
->IsTrue

+[HSL]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->IsntTrue

+[HSB]
~characterName="Система"
~characterExpression = 0
Ответ неверный. Попробуйте еще раз.
->IsntTrue

=== IsTrue ===
~characterName="Рассказчик"
~characterExpression = 0
Как только я закончил с заданием окно системы вновь исчезло, но теперь вместе с коррозией, а время начало свой ход. 

~characterName="Василиса Премудрая"
~characterExpression = 0
– Так, ребята, урок закончен, поэтому записываем домашнее задание. Необходимо написать небольшое эссе по теме сегодняшнего урока, весь необходимый материал вы найдете в своих учебниках. Всем приятного вечера.

~characterName="Василиса Премудрая"
~characterExpression = 1
Сообщила та всем.

~characterName="Рассказчик"
~characterExpression = 0
Юрий тяжело вздохнул, при этом вытирая пот со лба, что успел набежать, пока тот восстанавливал порядок строк в коде.

~Location = 1
~characterName="Ольга"
~characterExpression = 0
– Юрий, Мы пойдём с Мирой в библиотеку, хотели кое-что посмотреть по теме урока, - подойдя к тому, сказала Ольга.


+[Тогда удачи вам, надеюсь вы найдете то, что вам нужно.]
->answer4


+[Тогда до завтра и удачи в библиотеке.]
~characterName="Система"
~characterExpression = 0
Ваша симпатия с Ольгой поднялась на 20 единиц.
->answer4

=== answer4 ===
~characterName="Ольга"
~characterExpression = 1
– Большое спасибо, Юрий.

 ~characterName="Ольга"
~characterExpression = 4
Мягко улыбнувшись, сказал Ольга.

~characterName="Мира"
~characterExpression = 2
– Большущее спасибо, Юрий.

~characterName="Мира"
~characterExpression = 4
Также сказала Мира, широко улыбаясь и махая при этом одной рукой, другой же держась за стоящую рядом Ольгу.

~characterName="Рассказчик"
~characterExpression = 0
А после Юрий повернулся в другую сторону и пошел в сторону общежития.

~characterName="Рассказчик"
~characterExpression = 0
~Location = 0
Дойдя до него без происшествий, тот решил не откладывать на потом домашнее задание, а потому сразу же приступил к нему.

~characterName="Рассказчик"
~characterExpression = 0
Закончив спустя пару часов и уже сходив поужинав, тот думал о сегодняшнем дне уже находясь в постели.

~characterName="Юрий"
~characterExpression = 0
– «А мне все больше нравится в этом мире», - думал тот. - «Даже эти ошибки не сильно пугают. Да и у меня наконец появились друзья.»

~characterName="Рассказчик"
~characterExpression = 0
И с этими мыслями Юрий погрузился в сон, отдаваясь во власть Морфея.

    -> END
